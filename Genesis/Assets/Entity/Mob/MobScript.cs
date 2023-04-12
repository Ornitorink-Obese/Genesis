using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobScript : EntityScript
{
    public CapsuleCollider2D mobCollider;
    public bool atak;
    
    // Start is called before the first frame update
    public int damage;
<<<<<<< HEAD
    public Rigidbody2D bob;
    public PlayerScript joueur;
=======
    public GameObject itemsDropped;
    public CircleCollider2D weaponCollider;
>>>>>>> 5f7691a41df6253c911801ff6ea759fd81834a46

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


    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,PlayerScript.instance.GetComponent<Rigidbody2D>().position) < 5.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerScript.instance.GetComponent<Rigidbody2D>().position , speed * Time.deltaTime);
        }

        if (PlayerScript.instance.playerCollider.IsTouching(mobCollider))
        {
            StartCoroutine(Waitfor());
        }

<<<<<<< HEAD
        if (mobCollider.IsTouching(player.weaponCollider))
        {
            health -= 5;
            StartCoroutine(Wait(1));
        }

        IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
        
=======
        if (Input.GetKeyDown(KeyCode.K))
            health = 0;
>>>>>>> 5f7691a41df6253c911801ff6ea759fd81834a46
        if (health <= 0)
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
<<<<<<< HEAD
            joueur.health = joueur.health - damage;
            Vector2 back = transform.position;
            if(bob.position.x < transform.position.x)
            {
                back.x = back.x - 6;
            }
=======
            if (collision is CapsuleCollider2D)
            {
                HealthManager.instance.TakeDamage(damage);
                Vector2 back = transform.position;
                if (PlayerScript.instance.GetComponent<Rigidbody2D>().position.x < transform.position.x)
                {
                    back.x = back.x - 6;
                    back.x--;
                }
>>>>>>> 5f7691a41df6253c911801ff6ea759fd81834a46

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
<<<<<<< HEAD
                back.x = back.x + 6 ;
=======
                atak = false;
                TakeDamage(PlayerScript.instance.damage);
                StartCoroutine(Wait(2));
                atak = true;
>>>>>>> 5f7691a41df6253c911801ff6ea759fd81834a46
            }
        }
    }

<<<<<<< HEAD
=======
    private void ItemDrop()
    {
        Instantiate(itemsDropped, transform.position, quaternion.identity);
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

>>>>>>> 5f7691a41df6253c911801ff6ea759fd81834a46
    IEnumerator Waitfor()
    {
        yield return new WaitForSecondsRealtime(10);
    }

}
