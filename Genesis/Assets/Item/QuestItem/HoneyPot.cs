using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPot : QuestItem
{
    public HoneyPot()
    {
        ItemType = Quest.Type.GOOD;
        in_range_text = "Appuyez sur E pour ramasser";
    }
}
