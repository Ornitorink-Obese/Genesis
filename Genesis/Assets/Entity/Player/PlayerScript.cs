using UnityEngine;

public class PlayerScript : EntityScript
{
    public Rigidbody2D body;
    public HealthBar healthBar;
    public Collider2D PlayerCollider;
    
    public int maxHealth = 100;
    public int currentHealth;
    
    
    void Start()
    {
        speed = 10;
        currentHealth = 80;
        healthBar.SetHealth(currentHealth);
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

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        speed = 0;
        body.bodyType = RigidbodyType2D.Kinematic;
        PlayerCollider.enabled = false; 
        GameOverPanel.instance.OnPlayerDeath();
    }
    
    public void TakeDamage(int damage)
    {
        if (currentHealth != 0)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }

    public bool HealPlayer(int heal)
    {
        if (currentHealth != maxHealth)
        {
            if (currentHealth + heal > 100)
                currentHealth = heal;
            
            else
                currentHealth += heal;
            
            healthBar.SetHealth(currentHealth);
            return true;
        }

        return false;
    }
}
