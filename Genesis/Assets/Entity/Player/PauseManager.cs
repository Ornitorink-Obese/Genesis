using Mirror;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject gamePausedPanel;
    private bool GameIsPaused = false;
    public NetworkManager networkManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(gamePausedPanel);
            
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
        
        gamePausedPanel.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        networkManager.StopHost();
    }

    public void Quit()
    {
        networkManager.StopHost();
        Application.Quit();
    }
}
