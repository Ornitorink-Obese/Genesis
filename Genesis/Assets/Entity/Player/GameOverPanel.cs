using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : NetworkBehaviour
{
    public GameObject Panel;
    public NetworkManager NetworkManager;
    private Vector3[] startingcoordinates = new []{new Vector3(10, -11), new Vector3(-12, -28), new Vector3(-10, -13)};
    
    public static GameOverPanel instance;

    private void Awake()
    {
        if (instance != null)
            Debug.Log("there is already a GameOverPanel instance");

        else
            instance = this;
    }

    public void Activate()
    {
        Panel.SetActive(true);
    }
    
    public void Quit()
    {
        if (isServer)
            NetworkManager.StopHost();
        else 
            NetworkManager.StopClient();
        
        Application.Quit();
    }

    public void MainMenu()
    {
        Panel.SetActive(false);
        if (isServer)
        {
            Debug.Log("is server");
            NetworkManager.StopHost();
        }
        else
        {
            Debug.Log("is not server");
            NetworkManager.StopClient();
        }
    }

    public void Retry()
    {
        Panel.SetActive(false);
        HealthManager.instance.HealPlayer(100);
        string current = SceneManager.GetActiveScene().name;
        Vector3 coordinates;
        switch (current)
        {
            case "IntroScene" :
                coordinates = startingcoordinates[0];
                break;
            case "Level1" :
                coordinates = startingcoordinates[1];
                break;
            case "Level2" :
                coordinates = startingcoordinates[2];
                break;
            default:
                coordinates = new Vector3(0, 0, 0);
                break;
        }

        GameObject.FindGameObjectWithTag("Player").transform.position = coordinates;
        NetworkManager.ServerChangeScene(current);
    }
}
