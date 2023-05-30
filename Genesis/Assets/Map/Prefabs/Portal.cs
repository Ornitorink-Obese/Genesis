using Mirror;
using UnityEngine;

public class Portal : NetworkBehaviour
{
    [SerializeField] private string Scene_name;

    [SerializeField] private Vector3 coordinate;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isServer && col is CapsuleCollider2D)
        {
            NetworkManager.singleton.ServerChangeScene(Scene_name);
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                player.transform.position = coordinate;
            }

            Debug.Log("scene changed");
        }
    }
}