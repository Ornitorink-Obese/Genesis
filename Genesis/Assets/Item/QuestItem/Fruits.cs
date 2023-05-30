using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruits : QuestItem
{
    public Fruits()
    {
        ItemType = Quest.Type.BAD;
        in_range_text = "Appuyez sur E pour manger";
    }

    void Start()
    {
        PlayerInRangeText = GameObject.FindGameObjectWithTag("PlayerInRangeTxt").GetComponent<Text>();
    }
    public Text PlayerInRangeText;
    void OnTriggerEnter2D(Collider2D player) 
    {
        if (player.CompareTag("Player")&& player.GetType()==typeof(PolygonCollider2D))
        {
            playerinrange = true;
            PlayerInRangeText.text = in_range_text;
            Debug.Log("Affichage");
            PlayerInRangeText.enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player")&& player.GetType()==typeof(PolygonCollider2D))
        {
            playerinrange = false;
            PlayerInRangeText.text = in_range_text;
            PlayerInRangeText.enabled = false;
        } 
    }
}
