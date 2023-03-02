using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

    public void ContinueADialogue()
    {
        if (dialogue.Count == 0)
        {
			panel.SetBool("isOpen",false);
            return;
        }

        Texte.text = dialogue.Dequeue();
    }
}
