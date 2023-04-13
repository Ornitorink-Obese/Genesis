using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialsword : MonoBehaviour
{
    public GameObject portal;
    
    private void OnTriggerEnter2D(Collider2D player) 
    {
        if (player.CompareTag("Player"))
        {
            Debug.Log("Player collision");
            portal.SetActive(true);
            gameObject.SetActive(false); 
        }
    }
}
