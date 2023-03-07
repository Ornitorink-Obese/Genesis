using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class MobScript : EntityScript
{
    public Collider2D mobCollider;
    public PlayerScript player;
    public bool atak;
    
    public int damage;
    public Rigidbody2D bob;
    public PlayerScript joueur;
    public GameObject itemsDropped;


    void Start()
    {
        atak = false;
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
<<<<<<< HEAD
                back.x = back.x - 6;
=======
                back.x --;
>>>>>>> bf82e1272ce04022dae764c779c8fa4f0be5c7df
            }

            else
            {
<<<<<<< HEAD
                back.x = back.x + 6 ;
=======
                back.x --;
>>>>>>> bf82e1272ce04022dae764c779c8fa4f0be5c7df
            }

            transform.position = Vector2.MoveTowards(transform.position, back , speed * Time.deltaTime);
            StartCoroutine(Waitfor());
        }
 
    }

    private void ItemDrop()
    {
        Instantiate(itemsDropped, transform.position, quaternion.identity);
    }

    IEnumerator Waitfor()
    {
        yield return new WaitForSecondsRealtime(10);
    }

}
