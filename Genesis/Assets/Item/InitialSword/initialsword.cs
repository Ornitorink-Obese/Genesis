using UnityEngine;
using UnityEngine.UI;

public class initialsword : MonoBehaviour
{
    public GameObject portal;
    private bool playerInRange;
    public Text PlayerInRangeText;
    

    private void Update()
    {
        if (playerInRange & Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("récupéré");
            portal.SetActive(true);
            PlayerInRangeText.enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col is PolygonCollider2D)
        {
            playerInRange = true;
            PlayerInRangeText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other is PolygonCollider2D)
        {
            playerInRange = false;
            PlayerInRangeText.enabled = false;
        }
    }
}
