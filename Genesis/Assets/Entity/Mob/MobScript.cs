using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class MobScript : EntityScript
{
    public Collider2D mobCollider;
    public PlayerScript player;
    
    public int damage;
    public Rigidbody2D bob;
    public PlayerScript joueur;
    public GameObject itemsDropped;


    void Start()
    {
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
            ItemDrop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            joueur.health -= damage;
            Vector2 back = transform.position;
            if(bob.position.x < transform.position.x)
            {
                back.x --;
            }

            else
            {
                back.x --;
            }

            transform.position = Vector2.MoveTowards(transform.position, back , speed * Time.deltaTime);
            StopAllCoroutines();
            Time.timeScale = 5f;
            StartCoroutine(Waitfor());
        }
 
    }

    private void ItemDrop()
    {
        Instantiate(itemsDropped, transform.position, quaternion.identity);
    }

    IEnumerator Waitfor()
    {
        Debug.Log(Time.time);
        yield return new WaitForSecondsRealtime(50f);
        Debug.Log(Time.time);
    }

}
