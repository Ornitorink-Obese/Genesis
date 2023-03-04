using UnityEngine;
using System;

[Serializable]
public class Quest
{
    public string QuestName;
    
    [TextArea(3,10)]
    public string QuestDescription;

    public enum Status
    {
        UNASSIGNED,
        ASSIGNED,
        FINISHGOOD,
        FINISHBAD
    }
    
    public Status QuestStatus;
}
