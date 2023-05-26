using System;
using System.Collections;
using Mirror;
using UnityEngine;

public class MenuPrincipalScript : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject MultiPlayerPanel;
    public GameObject Continue_Button;
    public GameObject healthbar;
    public NetworkManager networkManager;

    public static bool loadSavedData;
    
    private void Start()
    {
        if(System.IO.File.Exists(Application.persistentDataPath + "/SavedData.json"))
            Continue_Button.SetActive(true);
    }

    public void Play()
    {
        loadSavedData = false;
        healthbar.SetActive(true);
        networkManager.StartHost();
    }

    void Continue()
    {
        loadSavedData = true;
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
