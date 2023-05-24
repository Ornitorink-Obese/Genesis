using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class QuestItem : ItemScript
{
    public Quest.Type ItemType;
    private Text PlayerInRangeText;
    public bool playerinrange;
    public string in_range_text;
    void Start()
    {        
        gameObject.SetActive(true);
        PlayerInRangeText = GameObject.FindGameObjectWithTag("PlayerInRangeTxt").GetComponent<Text>();
    }
    
    void OnTriggerEnter2D(Collider2D player) 
    {
        if (player.CompareTag("Player"))
        {
            playerinrange = true;
            PlayerInRangeText.enabled = true;
            PlayerInRangeText.text = in_range_text;
        }
    }
    void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            playerinrange = false;
            PlayerInRangeText.enabled = false;
            PlayerInRangeText.text = in_range_text;
        } 
    }

    void Update()
    {
        if (playerinrange & Input.GetKeyDown(KeyCode.E))
        {
            QuestManager.instance.FinishAQuest(ItemType);
            Destroy(gameObject);
        }
    }
    
}
