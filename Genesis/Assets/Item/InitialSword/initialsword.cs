using UnityEngine;

public class initialsword : MonoBehaviour
{
    public GameObject portal;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D player) 
    {
        if (player.CompareTag("Player"))
        {
            portal.SetActive(true);
            Destroy(gameObject);
        }
    }
}
