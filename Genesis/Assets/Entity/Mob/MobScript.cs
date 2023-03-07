using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class MobScript : EntityScript
{
    public CapsuleCollider2D mobCollider;
    public bool atak;
    
    public int damage;
    public Rigidbody2D bob;
    public PlayerScript joueur;
    public GameObject itemsDropped;
    public CircleCollider2D weaponCollider;

    IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    void Start()
    {
        atak = true;
        health = 20;
        enabled = true;
        damage = 10;
        speed = 5;
    }


    void Update()
    {
        if (Vector2.Distance(transform.position,bob.position) < 5.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, bob.position , speed * Time.deltaTime);
        }

        if (joueur.playerCollider.IsTouching(mobCollider))
        {
            StartCoroutine(Waitfor());
        }

        if (Input.GetKeyDown(KeyCode.K))
            health = 0;
        if (health <= 0)
        {
            Destroy(transform.gameObject);
            ItemDrop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision is CapsuleCollider2D)
            {
                joueur.health -= damage;
                Vector2 back = transform.position;
                if (bob.position.x < transform.position.x)
                {
                    back.x = back.x - 6;
                    back.x--;
                }

                else
                {
                    back.x = back.x + 6;
                    back.x--;
                }

                transform.position = Vector2.MoveTowards(transform.position, back, speed * Time.deltaTime);
                StartCoroutine(Waitfor());
            }
            else if (collision is CircleCollider2D && atak)
            {
                atak = false;
                TakeDamage(damage);
                StartCoroutine(Wait(2));
                atak = true;
            }
        }
    }

    private void ItemDrop()
    {
        Instantiate(itemsDropped, transform.position, quaternion.identity);
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    IEnumerator Waitfor()
    {
        yield return new WaitForSecondsRealtime(10);
    }

}
