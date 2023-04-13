using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ChoicesManager : MonoBehaviour
{
    public static ChoicesManager instance;

    public Text Name_Choices;
    public Text Texte_Choices;
    public Text choice1;
    public Text choice2;
    public Text choice3;
    public Animator choice_panel;
    // Start is called before the first frame update
    private void Awake()
    {
        // UNICITE DU PANEL : UN SEUL A LA FOIS DANS LA SCENE
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scène");  
            return;
        }
        instance = this; 
    }

    public void StartChoices(NpcScript npc)
    {
        choice_panel.SetBool("isOpen", true);
        Name_Choices.text = npc.NPCName;
        Texte_Choices.text = npc.NPCDialogue[0].texte[0];
        choice1.text = npc.Dialogue_Choices[0];
        choice2.text = npc.Dialogue_Choices[1];
        choice3.text = npc.Dialogue_Choices[2];
    }

    public void FinishChoices()
    {
        choice_panel.SetBool("isOpen", false);
    }

}
