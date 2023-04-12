using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobScript : EntityScript
{
    public Collider2D mobCollider;
    public PlayerScript player;
    public bool atak;
    
    // Start is called before the first frame update
    public int damage;
    public Rigidbody2D bob;
    public PlayerScript joueur;


    void Start()
    {
        atak = false;
        health = 20;
        enabled = true;
        damage = 10;
        speed = 5;
    }


    // Update is called once per frame
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

        if (mobCollider.IsTouching(player.weaponCollider))
        {
            health -= 5;
            StartCoroutine(Wait(1));
        }

        IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
        
        if (health <= 0)
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            joueur.health = joueur.health - damage;
            Vector2 back = transform.position;
            if(bob.position.x < transform.position.x)
            {
                back.x = back.x - 6;
            }

            else
            {
                back.x = back.x + 6 ;
            }

            transform.position = Vector2.MoveTowards(transform.position, back , speed * Time.deltaTime);
            StartCoroutine(Waitfor());
        }
 
    }

    IEnumerator Waitfor()
    {
        yield return new WaitForSecondsRealtime(10);
    }

}
