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
        FINISHED
    }

    public enum Type
    {
        GOOD,
        BAD
    }
    public Status QuestStatus;

    public Type QuestType;


}
