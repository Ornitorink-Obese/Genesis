using Mirror;
using UnityEngine;
using UnityEngine.Video;

public class cutscene : MonoBehaviour
{
    [SerializeField] private VideoPlayer VideoPlayer;
    private GameObject healthbar;
    private NetworkManager networkManager;
    private GameObject saves_empty;

    private void Start()
    {
        var test = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (var gameObject in test)
        {
            if (gameObject.CompareTag("Healthbar"))
            {
                healthbar = gameObject;
                Debug.Log("healthbar found");
            }


            if (gameObject.CompareTag("Saves_empty"))
            {
                saves_empty = gameObject;
                Debug.Log("saves found");
            }
        }
        
        networkManager = FindObjectOfType<NetworkManager>();
        VideoPlayer.loopPointReached += VideoEnded;
    }

    void VideoEnded(VideoPlayer videoPlayer)
    {
        PointSystem.loadSavedData = false;
        PointSystem.singleplayer = true;
        healthbar.SetActive(true);
        networkManager.StartHost();
        saves_empty.SetActive(true);
    }
    
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        
        PointSystem.loadSavedData = false;
        PointSystem.singleplayer = true;
        healthbar.SetActive(true);
        networkManager.StartHost();
        saves_empty.SetActive(true);
    }
}
