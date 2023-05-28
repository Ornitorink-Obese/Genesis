using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private Queue<string> dialogue;
    public Text Name_Dialogue;
    public Text Texte_Dialogue;
    public Animator dialogue_panel;
    private void Awake()
    {
        // UNICITE DU DIALOGUE : UN SEUL A LA FOIS DANS LA SCENE
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scène");  
            return;
        }
        dialogue = new Queue<string>(); 
        instance = this; 
    }

    public void StartADialogue(NpcScript npc)
    {
        dialogue_panel.SetBool("isOpen", true); //Apparition du Panel de texte
        dialogue.Clear(); //Au cas où l'ancien dialogue n'a pas vider la file
        foreach (string texteframe in npc.NPCDialogue[npc.Dialogue_Part].texte)
        {
            //Debug.Log(texteframe);
            dialogue.Enqueue(texteframe); //REMPLI LES PARTIES DU DIALOGUE SOUS FORME DE FILES
        }
        Name_Dialogue.text = npc.NPCName;
        ContinueADialogue();
    }

    public bool ContinueADialogue()
    {
        //Debug.Log(dialogue.Count);
        if (dialogue.Count == 0)
        {
			dialogue_panel.SetBool("isOpen",false); //Masque le panel de dialogue
            return true;
        }
        string text = dialogue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(text));
        return false;
    }
    
    IEnumerator TypeSentence(string sentence) //Ecrire le texte lettre par lettre
    {
        Texte_Dialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            Texte_Dialogue.text += letter;
            yield return null;
        }
    }
}
