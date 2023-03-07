using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public PlayerScript playerScript;
    public int Heal = 20;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (playerScript.HealPlayer(Heal))
                Destroy(gameObject);
        }
    }
}
