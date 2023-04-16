using System;
using UnityEngine;
//using Input = System.Windows.Input;

public class HealPowerUp : MonoBehaviour
{
    public int Heal = 20;
    
    private bool _isOnPlayer;

    private const KeyCode InputKey = KeyCode.Keypad0; // The key one has to press to take the heal
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            _isOnPlayer = true;
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            _isOnPlayer = false;
    }

    private void Update()
    {
        if (_isOnPlayer)
        {
            if (Input.GetKey(InputKey))
            {
                if (HealthManager.instance.HealPlayer(Heal))
                    Destroy(gameObject);
            }
        }
    }
}
