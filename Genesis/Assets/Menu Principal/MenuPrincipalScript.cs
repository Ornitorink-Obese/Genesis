using System;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalScript : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject MultiPlayerPanel;
    public GameObject healthbar;
    public NetworkManager networkManager;
    
    public void Play()
    {
        healthbar.SetActive(true);
        networkManager.StartHost();
    }

    public void MultiPlayer()
    {
        MultiPlayerPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SettingsPanel.SetActive(true);
    }
}
