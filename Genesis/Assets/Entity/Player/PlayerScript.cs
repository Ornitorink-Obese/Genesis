using UnityEngine;

public class PlayerScript : EntityScript
{
    public Rigidbody2D body;
    public HealthBar healthBar;
    
    public int maxHealth = 100;
    public int currentHealth;
    
    
    void Start()
    {
        speed = 10;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
    }

    void TakeDamage(int damage)
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
            currentHealth += heal;
            healthBar.SetHealth(currentHealth);
            return true;
        }

        return false;
    }
}
