using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameObject Panel;
    
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
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("1erSoutenance");
    }
}
