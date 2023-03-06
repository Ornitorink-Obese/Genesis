using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene("1erSoutenance");
    }
}
