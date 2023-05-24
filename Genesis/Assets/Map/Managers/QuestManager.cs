using System;
using UnityEngine;
using UnityEngine.UI;

public class InvalidQuestType : Exception
{
    public InvalidQuestType() { }
    public InvalidQuestType(string message) : base(message) { }
}

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    private Quest ActualQuest;

    public Animator QuestPanel;
    public Text Name;
    public Text Description;
    public GameObject Logo;
    public GameObject GoodFace;
    public GameObject BadFace;


    
    private void Awake()
    {
        // UNICITE DES QUÊTES : UNE SEULE A LA FOIS DANS LA SCENE
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de QuestManager dans la scène");
            return;
        }
        instance = this;

        Name = GameObject.FindGameObjectWithTag("Name").GetComponent<Text>();
        Description = GameObject.FindGameObjectWithTag("Description").GetComponent<Text>();
        Logo = GameObject.FindGameObjectWithTag("Logo");
        GoodFace = GameObject.FindGameObjectWithTag("GoodFace");
        BadFace = GameObject.FindGameObjectWithTag("BadFace");
        QuestPanel = GameObject.FindGameObjectWithTag("Quest Panel").GetComponent<Animator>();
        
        GoodFace.SetActive(false);        
        BadFace.SetActive(false);

        Logo.SetActive(true);
    }

    public void StartAQuest(Quest quest)
    {
        ActualQuest = quest; 
        ActualQuest.QuestStatus = Quest.Status.ASSIGNED; //Status de la quête -> Assignée
        Name.text = ActualQuest.QuestName; //Afficher nom de la quête
        Description.text = ActualQuest.QuestDescription; //Afficher description de la quête
        Logo.SetActive(true);
        QuestPanel.SetBool("isOpen",true); //Ouverture du panel
    }

    public void FinishAQuest(Quest.Type type)
    {
        ActualQuest.QuestStatus = Quest.Status.FINISHED; //Status de la quête -> Finie
        if (type == Quest.Type.GOOD)
        {
            PointSystem.instance.AddGoodPoints(1);
            FinishGood();
        }
        if (type == Quest.Type.BAD)
        {
            PointSystem.instance.AddBadPoints(1);
            FinishBad();
        }
        
        QuestPanel.SetBool("isOpen",false); //Fermeture Panel
        return;
    }
    

    private void FinishGood() //Gestion UI
    {
        Logo.SetActive(false);
        GoodFace.SetActive(true);
        BadFace.SetActive(false);
    }
    private void FinishBad() //Gestion UI
    {
        Logo.SetActive(false);
        GoodFace.SetActive(false);
        BadFace.SetActive(true);
    }

}
