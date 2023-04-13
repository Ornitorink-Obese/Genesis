using UnityEngine;

public class initialsword : MonoBehaviour
{
    public GameObject portal;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        Debug.Log(gameObject.activeInHierarchy);
    }

    private void OnTriggerEnter2D(Collider2D player) 
    {
        if (player.CompareTag("Player"))
        {
            Debug.Log("Player collision");
            portal.SetActive(true);
            Destroy(gameObject);
        }
    }
}
