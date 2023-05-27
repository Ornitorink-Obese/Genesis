using System;
using UnityEngine;
using UnityEngine.UI;

public class NpcScript : EntityScript
{
    public bool DEBUG;
    // -------------------------- CARACTERISTIQUES ----------------- //
    public string NPCName;
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
    

    void Start()
    {
        i = 0;
        PlayerInRangeText = GameObject.FindGameObjectWithTag("PlayerInRangeTxt").GetComponent<Text>();
        already_choice = false;
button1=GameObject.FindGameObjectWithTag("Button1").GetComponent<Button>();
button2=GameObject.FindGameObjectWithTag("Button2").GetComponent<Button>();
button3=GameObject.FindGameObjectWithTag("Button3").GetComponent<Button>();

    }

    void Update()
    {
        if (PlayerInRange)
        {
            // Get choice of player
            if (Input.GetKeyDown(KeyCode.E) && Dialogue_Part == 0)
            {
                PlayerInRangeText.enabled = false;
                GetChoice();
            }
            // Continue Dialogue if don't finished
            if (Input.GetKeyDown(KeyCode.Return) && Dialogue_Part != 0)
            {
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
                }
                else
                {
                    Dialogue_Part = 5;
                    DialogueManager.instance.StartADialogue(this);
                }
            }
        }
        else
        {
			PlayerInRangeText.enabled = false;
            GoToNextPoint(); //Facultatif : Deplacement prochain point
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
            PlayerInRangeText.enabled = true;
            speed = 0;
        } 
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
            speed = 1;
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
if (Dialogue_Part==3)
{
            QuestManager.instance.StartAQuest(this.NPCQuest);
            NPCBody.position = final_point;
            points = new Vector2[] { final_point };
            speed = 100;
}
else{
Debug.Log("FINISH");
//if (NPCQuest.
Dialogue_Part = 0;
ActivateButton();
GetChoice();
already_choice=false;
}
        }
    }

    private void GetChoice()
    {
        ChoicesManager.instance.StartChoices(this);
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
button1.interactable = false;
button2.interactable = false;
button3.interactable=false;
}

private void ActivateButton()
{
button1.interactable = true;
button2.interactable = true;
button3.interactable=true;
}
}
