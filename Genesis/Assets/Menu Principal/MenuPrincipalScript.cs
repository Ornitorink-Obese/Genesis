using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalScript : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject MultiPlayerPanel;

    public void Play()
    {
        SceneManager.LoadScene("1erSoutenance");
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
