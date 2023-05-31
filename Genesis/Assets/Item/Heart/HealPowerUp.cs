using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int Heal = 50;
    
    private bool _isOnPlayer;

    private const KeyCode InputKey = KeyCode.Keypad0; // The key one has to press to take the heal

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            _isOnPlayer = true;
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.GetType() == typeof(PolygonCollider2D))
            _isOnPlayer = false;
    }

    private void Update()
    {
        if(_isOnPlayer && Input.GetKeyDown(KeyCode.E))
            if(HealthManager.instance.HealPlayer(Heal))
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
                Destroy(this);
            }
    }
}
