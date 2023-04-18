using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class MobScript : EntityScript
{
    public CapsuleCollider2D mobCollider;
    public Animator animator;
    
    public bool atak;
    
    public int damage;
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
        //animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Vector2.Distance(transform.position,PlayerScript.instance.GetComponent<Rigidbody2D>().position) < 5.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerScript.instance.GetComponent<Rigidbody2D>().position , speed * Time.deltaTime);
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (PlayerScript.instance.playerCollider.IsTouching(mobCollider))
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
                HealthManager.instance.TakeDamage(damage);
                Vector2 back = transform.position;
                if (PlayerScript.instance.GetComponent<Rigidbody2D>().position.x < transform.position.x)
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
                TakeDamage(PlayerScript.instance.damage);
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
