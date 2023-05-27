using System;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saves : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        if(MenuPrincipalScript.loadSavedData)
            LoadData();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5))
            SaveData();
           
        if(Input.GetKeyDown(KeyCode.F9))
            LoadData();
    }

    public void SaveData()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SavedData savedData = new SavedData()
        {
            position = player.transform.position,
            health = HealthManager.instance.health,
            level = SceneManager.GetActiveScene().name,
            goodpoints = PointsManager.instance.good,
            badpoints = PointsManager.instance.bad,
        };

        string jsonData = JsonUtility.ToJson(savedData);
        string filepath = Application.persistentDataPath + "/SavedData.json";
        Debug.Log(filepath);
        System.IO.File.WriteAllText(filepath, jsonData);
        Debug.Log("save done");
    }

    public void LoadData()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        string filepath = Application.persistentDataPath + "/SavedData.json";
        string jsonData = System.IO.File.ReadAllText(filepath);

        SavedData savedData = JsonUtility.FromJson<SavedData>(jsonData);

        NetworkManager.singleton.ServerChangeScene(savedData.level);
        player.transform.position = savedData.position;

        HealthManager.instance.health = savedData.health;
        HealthBar.instance.SetHealth(savedData.health);

        PointsManager.instance.bad = savedData.badpoints;
        PointsManager.instance.good = savedData.goodpoints;

        
        Debug.Log("load done");
    }
}

public class SavedData
{
    public Vector3 position;
    public int goodpoints;
    public int badpoints;
    public string level;
    public int health;
}
