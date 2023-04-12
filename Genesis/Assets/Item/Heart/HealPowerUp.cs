using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int Heal = 20;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (HealthManager.instance.HealPlayer(Heal))
                Destroy(gameObject);
        }
    }
}
