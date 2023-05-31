using UnityEngine;

public class TeleportOnCollision : MonoBehaviour
{
    public Vector2 teleportTarget;  // La position de téléportation cible

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType()==typeof(PolygonCollider2D))
        {
            // Téléportation du joueur à la position cible
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                player.transform.position = teleportTarget;
            }
        }
    }
}