using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    private Quest ActualQuest;

    public Animator panel;
    public Text Name;
    public Text Description;
    
    private void Awake()
    {
        //if(instance != null)
        //{
          //  Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scène");
            //return;
        //}
        instance = this;
    }

    public void StartAQuest(Quest quest)
    {
        ActualQuest = quest;
        ActualQuest.QuestStatus = Quest.Status.ASSIGNED;
        Name.text = quest.QuestName;
        Description.text = quest.QuestDescription;
        panel.SetBool("isOpen",true);
        return;
    }

    public void FinishGood()
    {
        ActualQuest.QuestStatus = Quest.Status.FINISHGOOD;
        panel.SetBool("isOpen",false);
        //Player points
        return;
    }
    
    public void Finishbad()
    {
        ActualQuest.QuestStatus = Quest.Status.FINISHBAD;
        panel.SetBool("isOpen",false);
        //Player points
        return;
    }
    
}
