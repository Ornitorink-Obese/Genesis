using UnityEngine;

public abstract class QuestItem : ItemScript
{
    public Quest.Type ItemType;
    public bool playerinrange;
    public string in_range_text;
    void Start()
    {        
        gameObject.SetActive(true);
    }
    
    
    
    

    void Update()
    {
        if (playerinrange & Input.GetKeyDown(KeyCode.E))
        {
            QuestManager.instance.FinishAQuest(ItemType);
            Destroy(gameObject);

            if (this is Fruits)
                HealthManager.instance.HealPlayer(5);
        }
    }
    
}
