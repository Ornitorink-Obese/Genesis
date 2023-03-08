using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    private Quest ActualQuest;

    public Animator QuestPanel;
    public Text Name;
    public Text Description;
    public GameObject Logo;
    public GameObject LogoValidate;

    

    public UnityEngine.Object CompleteType; //Objet visant à compléter la quête avec son type (mauvaise ou bonne)
    public UnityEngine.Object CompleteOpposedType; //Objet visant à compléter la quête avec son type opposé (mauvaise ou bonne)


    
    private void Awake()
    {
        // UNICITE DU QUÊTE : UN SEUL A LA FOIS DANS LA SCENE
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scène");
            return;
        }
        instance = this;
        LogoValidate.active = false;
        Logo.SetActive(true);
        CompleteOpposedType = null; // Pour la premiére soutenance
    }

    public void StartAQuest(Quest quest)
    {
        ActualQuest = quest; 
        ActualQuest.QuestStatus = Quest.Status.ASSIGNED; //Status de la quête -> Assigner
        Name.text = ActualQuest.QuestName; //Afficher nom de la quête
        Description.text = ActualQuest.QuestDescription; //Afficher description de la quête
        Logo.SetActive(true);
        QuestPanel.SetBool("isOpen",true); //Ouverture du panel
    }

    public void FinishAQuestType()
    {
        ActualQuest.QuestStatus = Quest.Status.FINISHED; //Status de la quête -> Fini
        Logo.SetActive(false);
        LogoValidate.SetActive(true);
        QuestPanel.SetBool("isOpen",false); //Fermeture Panel
        //Next soutenance : Player points
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
