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
    public GameObject LogoValidate;
    //public GameManager Game;
    

    public UnityEngine.Object CompleteType; //Objet visant à compléter la quête avec son type (mauvais ou bon)
    public UnityEngine.Object CompleteOpposedType; //Objet visant à compléter la quête avec son type opposé (mauvais ou bon)

    
    
    private void Awake()
    {
        // UNICITE DES QUÊTES : UNE SEULE A LA FOIS DANS LA SCENE
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scène");
            return;
        }
        instance = this;
        LogoValidate.SetActive(false);
        Logo.SetActive(true);
        CompleteOpposedType = null; // Pour la première soutenance
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

    public void FinishAQuestType()
    {
        ActualQuest.QuestStatus = Quest.Status.FINISHED; //Status de la quête -> Finie
        Logo.SetActive(false);
        LogoValidate.SetActive(true);
        QuestPanel.SetBool("isOpen",false); //Fermeture Panel
        PointSystem.instance.EndQuest(ActualQuest, 1); // Changer le nombre de points en fonction de la quête (ajouter un attribut à Quest)
        return;
    }

    public void Update()
    {
        if (!(ActualQuest is null) && ActualQuest.QuestStatus == Quest.Status.ASSIGNED && CompleteType == null)
        {
            FinishAQuestType();
        }
    }

}
