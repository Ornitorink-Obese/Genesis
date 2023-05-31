using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportOnCollision : MonoBehaviour
{
    [SerializeField] private string sceneTarget;
    public Vector2 teleportTarget;  // La position de téléportation cible

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && collision is PolygonCollider2D)
        {
            if(SceneManager.GetActiveScene().name != sceneTarget)
                FindObjectOfType<NetworkManager>().ServerChangeScene(sceneTarget);
            
            // Téléportation du joueur à la position cible
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                player.transform.position = teleportTarget;
            }
        }
    }
}