using UnityEngine;

public class PlayerScript : EntityScript
{
    public Rigidbody2D body;
    public HealthBar healthBar;
    public Collider2D PlayerCollider;
    public GameObject gameOverPanel;

    
    public int maxHealth = 100;

    void Start()
    {
        speed = 10;
        health = 80;
        healthBar.SetHealth(health);
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
        

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        speed = 0;
        body.bodyType = RigidbodyType2D.Kinematic;
        PlayerCollider.enabled = false; 
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
}
