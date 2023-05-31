using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : QuestItem
{
    private Text PlayerInRangeText;
    public Item()
    {
        in_range_text = "Appuyez sur E pour récolter";
    }
    void Start()
    {
        PlayerInRangeText = GameObject.FindGameObjectWithTag("PlayerInRangeTxt").GetComponent<Text>();
    }
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
