using Mirror;
using UnityEngine;

public class MenuPrincipalScript : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject MultiPlayerPanel;
    public GameObject Continue_Button;
    public GameObject healthbar;
    public NetworkManager networkManager;
    public GameObject saves_empty;

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
        string filepath = Application.persistentDataPath + "/SavedData.json";
        string jsonData = System.IO.File.ReadAllText(filepath);

        SavedData savedData = JsonUtility.FromJson<SavedData>(jsonData);
        networkManager.onlineScene = savedData.level;
        
        loadSavedData = true;
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
