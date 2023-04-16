using UnityEngine;
using UnityEngine.UI;

public class initialsword : MonoBehaviour
{
    public GameObject portal;
    private bool playerInRange;
    public Text PlayerInRangeText;


    private void Start()
    {
        gameObject.SetActive(true);
        PlayerInRangeText = GameObject.FindGameObjectWithTag("PlayerInRangeTxt").GetComponent<Text>();
    }

    private void Update()
    {
        if (playerInRange & Input.GetKeyDown(KeyCode.E))
        {
            portal.SetActive(true);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D player) 
    {
        if (player.CompareTag("Player"))
        {
            playerInRange = true;
            PlayerInRangeText.enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            playerInRange = false;
            PlayerInRangeText.enabled = false;
        } 
    }
}
