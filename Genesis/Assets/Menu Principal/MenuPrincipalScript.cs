using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalScript : MonoBehaviour
{
    public GameObject SettingsPanel;

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void Play()
    {
        SceneManager.LoadScene("1erSoutenance");
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
