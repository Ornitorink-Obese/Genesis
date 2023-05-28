using System;
using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D body;
    public Collider2D playerCollider;
    public Collider2D weaponCollider;
    public Collider2D detect;

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
        if (Input.GetKey(KeyCode.UpArrow))
            body.position += Vector2.up * (speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            body.position += Vector2.down * (speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            body.position += Vector2.left * (speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            body.position += Vector2.right * (speed * Time.deltaTime);
        
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(Attack());
        }
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
        animator.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("IsAttacking", false);
        weaponCollider.enabled = false;
        canAttack = true;
    }
}
