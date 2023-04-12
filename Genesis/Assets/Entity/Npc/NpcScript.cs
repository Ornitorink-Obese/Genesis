using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NpcScript : EntityScript
{
    public string NPCName;
    public Rigidbody2D NPCBody;
    public bool PlayerInRange;
    public Text PlayerInRangeText;

    public Dialogue NPCDialogue;
    public Vector2[] points;

    public Quest NPCQuest;
    private int i;

    public bool DEBUG;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerInRangeText.enabled = false;
                StartDialogue();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                PlayerInRangeText.enabled = false;
                ContinueDialogue();
                //DEBUG = true;
            }
        }
        else
        {
			PlayerInRangeText.enabled = false;
            GoToNextPoint();
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
            QuestManager.instance.StartAQuest(this.NPCQuest);
        }
    }

    private void GoToNextPoint()
    {
        Vector2 actual_pos = NPCBody.position;
        if (Math.Round(NPCBody.position.x) != points[i].x || Math.Round(NPCBody.position.y) != points[i].y)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[i], Time.deltaTime * speed);
        }
        else
        {
            
            i = (i + 1)%points.Length;
        }
    }
}
