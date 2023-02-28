using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NpcScript : EntityScript
{
    public string NPCName;
    public bool PlayerInRange;

    public Dialogue NPCDialogue;
    public Rigidbody2D body;
    
    public NavMeshAgent agent;
    public Transform[] points;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 8;
        //agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }

        agent.SetDestination(points[0].position);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
            speed = 0;
        } 
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
            speed = 4;
        } 
    }

    private void StartDialogue()
    {
        DialogueManager.instance.StartADialogue(this);
    }
}
