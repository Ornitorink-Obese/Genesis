using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public int health;
    private int maxHealth = 100;

    public static HealthManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("il y a plus d'une instance de HealthManager");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        health = 80;
        HealthBar.instance.SetHealth(health);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            TakeDamage(20);
        
        if (Input.GetKeyDown(KeyCode.RightShift))
            HealPlayer(100);
            
        if (health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        PlayerScript.instance.speed = 0;
        PlayerScript.instance.body.bodyType = RigidbodyType2D.Kinematic;
        PlayerScript.instance.playerCollider.enabled = false; 
        gameOverPanel.SetActive(true);
    }
    
    public void TakeDamage(int damage)
    {
        if (health != 0)
        {
            health -= damage;
            HealthBar.instance.SetHealth(health);
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
            
            HealthBar.instance.SetHealth(health);
            return true;
        }

        return false;
    }
}