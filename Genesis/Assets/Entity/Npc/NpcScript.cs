using System;
using System.Threading;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class NpcScript : MonoBehaviour
{
    public bool DEBUG;
    // -------------------------- CARACTERISTIQUES ----------------- //
    public string NPCName;
    public float speed;
    public Rigidbody2D NPCBody;
    public bool PlayerInRange;
    public Text PlayerInRangeText;
    public Dialogue[] NPCDialogue; 
    // First : Dialogue Panel Choice
    // Second : First Dialogue
    // Third : Second Dialogue
    // Fourth : Third Dialogue
    // Fifth : Final Good
    // Sixth : Final Bad
    public string[] Dialogue_Choices;
    // 3 differents choices
    public int Dialogue_Part;
    public Vector2[] points;
    // Facultatif : si le PNJ doit se déplacer. Est utilisé pour déplacer le PNJ à son point final

    public Vector2 final_point;
    private bool already_choice;
public Button button1;
public Button button2;
public Button button3;


    
    // ------------------------- QUEST ------------------------- //
    public Quest NPCQuest;
    private int i;

    private bool dialoguestart;
    public int timer;
    

    void Start()
    {
        i = 0;
        PlayerInRangeText = GameObject.FindGameObjectWithTag("PlayerInRangeTxt").GetComponent<Text>();
        already_choice = false;
button1=GameObject.FindGameObjectWithTag("Button1").GetComponent<Button>();
button2=GameObject.FindGameObjectWithTag("Button2").GetComponent<Button>();
button3=GameObject.FindGameObjectWithTag("Button3").GetComponent<Button>();
dialoguestart=false;
timer = 0;

    }

    void Update()
    {
        if (PlayerInRange)
        {
            timer += 1;
            Debug.Log(timer);
            if (timer >= 1000 && Dialogue_Part != 0 && NPCQuest.QuestStatus != Quest.Status.FINISHED)
            {
                ContinueDialogue();
                timer=0;
            }
            Debug.Log("UPDATE");
            // Get choice of player
            if (Input.GetKeyDown(KeyCode.E) && Dialogue_Part == 0 && NPCQuest.QuestStatus != Quest.Status.FINISHED)
            {
                PlayerInRangeText.enabled = false;
                GetChoice();
            }
            // Continue Dialogue if don't finished
            if (Input.GetKeyDown(KeyCode.Return) && Dialogue_Part != 0 && NPCQuest.QuestStatus != Quest.Status.FINISHED)
            {
                Debug.Log("NEXT");
                PlayerInRangeText.enabled = false;
                ContinueDialogue();
            }
            
            // Quest already finished
            if (Input.GetKeyDown(KeyCode.E) && NPCQuest.QuestStatus == Quest.Status.FINISHED)
            {
                if (NPCQuest.QuestType == Quest.Type.GOOD)
                {
                    Dialogue_Part = 4;
                    DialogueManager.instance.StartADialogue(this);
                    PlayerInRangeText.enabled = false;

                        dialoguestart=true;

                    }
                else
                {
                    Dialogue_Part = 5;
                    
                        DialogueManager.instance.StartADialogue(this);
                        PlayerInRangeText.enabled = false;

                        dialoguestart=true;
                    


                    
                }
            }

            if (Input.GetKeyDown(KeyCode.Return) && NPCQuest.QuestStatus == Quest.Status.FINISHED)
            {
                if (dialoguestart)
                {
                    DialogueManager.instance.ContinueADialogue();
                    
                    dialoguestart = false;
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            GoToNextPoint(); //Facultatif : Deplacement prochain point
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        i = 0;
        PlayerInRangeText = GameObject.FindGameObjectWithTag("PlayerInRangeTxt").GetComponent<Text>();
        already_choice = false;
        if (collision.CompareTag("Player") && collision.GetType()==typeof(PolygonCollider2D))
        {
            PlayerInRange = true;
            PlayerInRangeText.text = "Appuyez sur E pour interagir";
            PlayerInRangeText.enabled = true;
            speed = 0;
        } 
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& collision.GetType()==typeof(PolygonCollider2D))
        {
            PlayerInRange = false;
            speed = 1;
            PlayerInRangeText.enabled = false;
        } 
    }

    private void StartDialogue()
    {
        DialogueManager.instance.StartADialogue(this);
    }

    private void ContinueDialogue()
    {
        if (DialogueManager.instance.ContinueADialogue())
        {
            Debug.Log("FABIEN");
        if (Dialogue_Part==3)
        {
            QuestManager.instance.StartAQuest(this.NPCQuest);
            NPCBody.position = final_point;
            points = new Vector2[] { final_point };
            speed = 100;
        }
    else{
        Debug.Log("FINISH");

    Dialogue_Part = 0;
    ActivateButton();
    GetChoice();
    already_choice=false;
        }
        
        }
    }

    private void GetChoice()
    {
        Debug.Log("GETCHOICE");
        if (PlayerInRange)
        {
            ChoicesManager.instance.StartChoices(this);
        }
    }

    public void EndChoice(int change)
    {
        Debug.Log("Change : " + change);
        if (!already_choice)
        {
            already_choice = true;
            Dialogue_Part = change;
            ChoicesManager.instance.FinishChoices();
            StartDialogue();
DesactivateButton();
        }
    }
    private void GoToNextPoint()
    {
        Vector2 actual_pos = NPCBody.position;
        if (i < points.Length)
        {
            if (Math.Round(NPCBody.position.x) != points[i].x || Math.Round(NPCBody.position.y) != points[i].y)
            {
                transform.position = Vector2.MoveTowards(transform.position, points[i], Time.deltaTime * speed);
            }
            else
            {

                i = (i + 1) % points.Length;
            }
        }
    }

private void DesactivateButton()
{
    button1=GameObject.FindGameObjectWithTag("Button1").GetComponent<Button>();
    button2=GameObject.FindGameObjectWithTag("Button2").GetComponent<Button>();
    button3=GameObject.FindGameObjectWithTag("Button3").GetComponent<Button>();
    button1.interactable = false;
    if (button2 is not null) button2.interactable = false;
    if (button3 is not null) button3.interactable = false;
}

private void ActivateButton()
{
button1.interactable = true;
button2.interactable = true;
button3.interactable=true;
}
}
