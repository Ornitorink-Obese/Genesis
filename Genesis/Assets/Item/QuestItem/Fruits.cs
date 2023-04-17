using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : QuestItem
{
    public Fruits()
    {
        ItemType = Quest.Type.BAD;
        in_range_text = "Appuyez sur E pour manger";
    }
}
