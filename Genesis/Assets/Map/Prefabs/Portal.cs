using System;
using System.Collections;
using System.IO;
using Mirror;
using Mirror.Examples.AdditiveLevels;
using Mirror.Examples.Pong;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string Scene_name;

    [SerializeField] 
    private Vector3 coordinates;

    private void OnTriggerEnter2D(Collider2D col)
    {
        NetworkManager.singleton.ServerChangeScene(Scene_name);
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            player.transform.position = coordinates;
        }
        Debug.Log("scene changed");
    }

    /*[Scene, Tooltip("Which scene to send player from here")]
    public string destinationScene;

    public int targetSceneIndex;

    [Tooltip("Where to spawn player in Destination Scene")]
    public Vector2 startPosition;

    // This is approximately the fade time
    WaitForSeconds waitForFade = new WaitForSeconds(0f);

    public override void OnStartServer()
    {
        Debug.Log(destinationScene);

        destinationScene = Path.GetFileNameWithoutExtension(destinationScene);
        
        Debug.Log(destinationScene);
        Debug.Log(targetSceneIndex);
    }

    public override void OnStartClient()
    {
        // if (label.TryGetComponent(out LookAtMainCamera lookAtMainCamera))
        //     lookAtMainCamera.enabled = true;
    }

    // Note that I have created layers called Player(6) and Portal(7) and set them
    // up in the Physics collision matrix so only Player collides with Portal.
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision portal");
        // tag check in case you didn't set up the layers and matrix as noted above
        if (!other.CompareTag("Player"))
        {
            return;
        }

        // applies to host client on server and remote clients
        if (other.TryGetComponent(out PlayerController playerController))
        {
            playerController.enabled = false;
        }

        if (isServer)
        {
            StartCoroutine(SendPlayerToNewScene(other.gameObject));
        }
    }

    [ServerCallback]
    IEnumerator SendPlayerToNewScene(GameObject player)
    {
        if (player.TryGetComponent(out NetworkIdentity identity))
        {
            NetworkConnectionToClient conn = identity.connectionToClient;
            if (conn == null) yield break;

            // Tell client to unload previous subscene. No custom handling for this.
            conn.Send(new SceneMessage { sceneName = gameObject.scene.path, sceneOperation = SceneOperation.UnloadAdditive, customHandling = true });

            yield return waitForFade;

            NetworkServer.RemovePlayerForConnection(conn, false);


            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadSceneAsync(targetSceneIndex, LoadSceneMode.Additive);

            // reposition player on server and client
            player.transform.position = startPosition;

            // Move player to new subscene.
            SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByBuildIndex(targetSceneIndex));

            // Tell client to load the new subscene with custom handling (see NetworkManager::OnClientChangeScene).
            conn.Send(new SceneMessage { sceneName = destinationScene, sceneOperation = SceneOperation.LoadAdditive, customHandling = true });

            NetworkServer.AddPlayerForConnection(conn, player);

            
            // host client would have been disabled by OnTriggerEnter above
            if (NetworkClient.localPlayer != null && NetworkClient.localPlayer.TryGetComponent(out PlayerController playerController))
                playerController.enabled = true;
        }
    }*/
}