using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalScript : MonoBehaviour
{
    public GameObject SettingsPanel;


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
