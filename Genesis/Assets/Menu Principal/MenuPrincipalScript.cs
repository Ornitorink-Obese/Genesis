using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalScript : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject MultiPlayerPanel;
    public GameObject Continue_Button;
    public GameObject healthbar;
    public NetworkManager networkManager;
    public GameObject saves_empty;

    private void Start()
    {
        PointSystem.singleplayer = false;
        PointSystem.loadSavedData = false;

        if(System.IO.File.Exists(Application.persistentDataPath + "/SavedData.json"))
            Continue_Button.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("Cutscene");
    }

    void Continue()
    {
        string filepath = Application.persistentDataPath + "/SavedData.json";
        string jsonData = System.IO.File.ReadAllText(filepath);

        SavedData savedData = JsonUtility.FromJson<SavedData>(jsonData);
        networkManager.onlineScene = savedData.level;
        
        PointSystem.loadSavedData = true;
        PointSystem.singleplayer = true;
        networkManager.StartHost();
        healthbar.SetActive(true);
        saves_empty.SetActive(true);
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
