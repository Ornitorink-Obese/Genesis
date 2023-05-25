using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BourreauScript : MobScript
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damage = 40;
        speed = 2;
        atak = true;
        charge = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (havetarget && charge && infeinte == false && KB == false)
        {
            Vector2 direction = target.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            nf = Random.Range(0,10000);
            if (nf == 2000)
            {
                infeinte = true;
                feinte = transform.position;
                print("feinte");
                int howf = Random.Range(0,2);
                if (howf == 0)
                {
                    feinte.y = feinte.y + 3;
                    feinte.y--;
                }

                else
                {
                    feinte.y = feinte.y - 3;
                    feinte.y--;
                }
            }
        }

        if(KB)
        {
            transform.position = Vector2.MoveTowards(transform.position, recule, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, recule) == 0)
            {
                KB = false;
                print("BOUM!");
            }
        }


        if (infeinte)
        {
            transform.position = Vector2.MoveTowards(transform.position, feinte, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position,feinte) == 0)
            {
                infeinte = false;
                print("exit feinte");
            }
        }

        
        if (havetarget && charge == false && infeinte == false && KB == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, back, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, back) == 0)
            {
                charge = true;
                StartCoroutine(Waitfor());
            }
        }

        if (health <= 0)
        {
            Destroy(transform.gameObject);
            ItemDrop();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision is BoxCollider2D)
            {
                havetarget = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (collision is BoxCollider2D)
            {
                print("pastabox");
                havetarget = true;
                target = collision.gameObject;
            }

            if (collision is CapsuleCollider2D)
            {
                HealthManager.instance.TakeDamage(damage);
                print("charge");
                charge = false;
                back = transform.position;
                if (target.transform.position.x < transform.position.x)
                {
                    back.x = back.x + 3;
                    back.x--;
                }

                else
                {
                    back.x = back.x - 3;
                    back.x--;
                }
                
            }
            else if (collision is CircleCollider2D && atak)
            {
                print("tatakae");
                atak = false;
                TakeDamage(PlayerScript.instance.damage);
                KB = true;
                recule = transform.position;
                if (target.transform.position.x < transform.position.x)
                {
                    recule.x = recule.x + 2;
                    recule.x--;
                }

                else
                {
                    recule.x = recule.x - 2;
                    recule.x--;
                }
                StartCoroutine(Wait(2));
                atak = true;
            }
        }
    }
}
