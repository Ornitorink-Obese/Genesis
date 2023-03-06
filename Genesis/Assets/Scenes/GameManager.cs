using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gamePausedPanel;
    private bool GameIsPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();

            else
                Pause();
        }
    }

    public void Pause()
    {
        gamePausedPanel.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    
    public void Resume()
    {
        gamePausedPanel.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
