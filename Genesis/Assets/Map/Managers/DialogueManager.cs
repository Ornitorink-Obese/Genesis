using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private Queue<string> dialogue;
    public  Text Name;
    public Text Texte;
    public Animator panel;
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
        Name.text = npc.NPCName; //Apparition nom du NPC
		panel.SetBool("isOpen",true); //Apparition du Panel de texte
        dialogue.Clear(); //Au cas où l'ancien dialogue n'a pas vider la file
        foreach (string texteframe in npc.NPCDialogue.texte)
        {
            dialogue.Enqueue(texteframe); //REMPLI LES PARTIES DU DIALOGUE SOUS FORME DE FILES
        }

        ContinueADialogue();
    }

    public bool ContinueADialogue()
    {
        if (dialogue.Count == 0)
        {
			panel.SetBool("isOpen",false); //Masque le panel de dialogue
            return true;
        }

        string text = dialogue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(text)); 
        return false;
    }
    
    IEnumerator TypeSentence(string sentence) //Ecrire le texte lettre par lettre
    {
        Texte.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            Texte.text += letter;
            yield return null;
        }
    }
}
