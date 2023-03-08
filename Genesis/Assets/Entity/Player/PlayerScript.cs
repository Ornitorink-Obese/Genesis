using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : EntityScript
{
    public Rigidbody2D body;
    public HealthBar healthBar;
    public Collider2D playerCollider;
    public GameObject gameOverPanel;
    public Collider2D weaponCollider;

    public int maxHealth = 100;
    private bool canAttack;

    void Start()
    {
        speed = 10;
        health = 80;
        healthBar.SetHealth(health);
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
        
        if (Input.GetKeyDown(KeyCode.H))
            TakeDamage(20);
        
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(Attack());
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
            HealPlayer(100);
            
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        speed = 0;
        body.bodyType = RigidbodyType2D.Kinematic;
        playerCollider.enabled = false; 
        gameOverPanel.SetActive(true);
    }
    
    public void TakeDamage(int damage)
    {
        if (health != 0)
        {
            health -= damage;
            healthBar.SetHealth(health);
        }
    }

    public bool HealPlayer(int heal)
    {
        if (health != maxHealth)
        {
            if (health + heal > 100)
                health = heal;
            
            else
                health += heal;
            
            healthBar.SetHealth(health);
            return true;
        }

        return false;
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
