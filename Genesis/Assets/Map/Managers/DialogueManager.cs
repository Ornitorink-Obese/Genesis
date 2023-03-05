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
        //if(instance != null)
        //{
          //  Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scène");
            //return;
        //}
        dialogue = new Queue<string>();
        instance = this;
    }

    public void StartADialogue(NpcScript npc)
    {
        Name.text = npc.NPCName;
		panel.SetBool("isOpen",true);
        dialogue.Clear();
        foreach (string texteframe in npc.NPCDialogue.texte)
        {
            dialogue.Enqueue(texteframe);
        }

        ContinueADialogue();
    }

    public bool ContinueADialogue()
    {
        if (dialogue.Count == 0)
        {
			panel.SetBool("isOpen",false);
            return true;
        }

        string text = dialogue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(text));
        return false;
    }
    
    IEnumerator TypeSentence(string sentence)
    {
        Texte.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            Texte.text += letter;
            yield return null;
        }
    }
}
