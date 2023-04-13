using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class MultiPlayerScript : MonoBehaviour
{
    public NetworkManager networkManager;
    public GameObject CanvasPanel;
    public string adress;

    private void Start()
    {
        DontDestroyOnLoad(networkManager);
    }

    private void Update()
    {
        adress = networkManager.networkAddress;
    }

    public void Host()
    {
        CanvasPanel.SetActive(true);
        networkManager.StartHost();
        SceneManager.LoadScene(1);
    }

    public void Client()
    {
        networkManager.StartClient();
        SceneManager.LoadScene(1);
    }

    public void ChangeIP(string value)
    {
        networkManager.networkAddress = value;
        SceneManager.LoadScene(1);
    }
}