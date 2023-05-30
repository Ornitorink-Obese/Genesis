using System;
using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D body;
    public Collider2D playerCollider;
    public Collider2D weaponCollider;
    public Collider2D detect;
    public SpriteRenderer spritos;

    public int speed;
    public int damage;
    private bool canAttack;
    private Vector3 offset;
    public Animator animator;

    public static PlayerScript instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("il y a plus d'une instance de PlayerScript");
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        speed = 10;
        damage = 7;
        weaponCollider.transform.position = transform.position;
        weaponCollider.enabled = false;
        canAttack = true;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            animator.SetBool("atack",true);
            StartCoroutine(Attack());
        }

        if (Input.GetKey(KeyCode.Z))
        {
            body.position += Vector2.up * (speed * Time.deltaTime);
            animator.SetBool("idle",false);
            animator.SetBool("walk",true);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            body.position += Vector2.down * (speed * Time.deltaTime);
            animator.SetBool("idle",false);
            animator.SetBool("walk",true);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            animator.SetBool("idle",false);
            animator.SetBool("walk",true);
            body.position += Vector2.left * (speed * Time.deltaTime);
            spritos.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("idle",false);
            animator.SetBool("walk",true);
            body.position += Vector2.right * (speed * Time.deltaTime);
            spritos.flipX = false;
        }

        else
        {
            animator.SetBool("walk",false);
            animator.SetBool("idle",true);
        }
    }

    public void EndAtack()
    {
        animator.SetBool("atack",false);
    }

    public void EndHit()
    {
        animator.SetBool("hit",false);
    }

    public void EndDie()
    {
        animator.SetBool("die",false);
    }


    public IEnumerator Attack()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 pos = transform.position;
        float xDistance = mouse.x - pos.x;
        float yDistance = mouse.y - pos.y;
        double coeff = 2.5 / Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
        weaponCollider.offset = new Vector3((float)(pos.x * coeff), (float)(pos.y * coeff), 0);
        weaponCollider.enabled = true;
        // deals damage to mob
        canAttack = false;
        yield return new WaitForSeconds(1);
        weaponCollider.enabled = false;
        canAttack = true;
    }
}
