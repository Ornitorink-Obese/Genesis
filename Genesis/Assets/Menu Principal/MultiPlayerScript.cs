using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class MultiPlayerScript : MonoBehaviour
{
    public NetworkManager networkManager;
    public GameObject CanvasPanel;
    public GameObject ipTxt;
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
        ipTxt.SetActive(true);
        networkManager.StartHost();
    }

    public void Client()
    {
        networkManager.StartClient();
    }

    public void ChangeIP(string value)
    {
        networkManager.networkAddress = value;
    }
}