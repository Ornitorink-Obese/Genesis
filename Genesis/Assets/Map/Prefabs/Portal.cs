using Mirror;
using UnityEngine;

public class Portal : NetworkBehaviour
{
    [SerializeField] private string Scene_name;

    [SerializeField] private Vector3 coordinates;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isServer)
        {
            NetworkManager.singleton.ServerChangeScene(Scene_name);
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                player.transform.position = coordinates;
            }

            Debug.Log("scene changed");
        }
    }
}