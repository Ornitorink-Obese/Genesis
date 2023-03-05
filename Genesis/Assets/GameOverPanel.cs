using System;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverPanel;

    public static GameOverPanel instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverPanel dans la scène");
            return;
        }

        instance = this;
    }

    public void OnPlayerDeath()
    {
        gameOverPanel.SetActive(true);
    }
}
