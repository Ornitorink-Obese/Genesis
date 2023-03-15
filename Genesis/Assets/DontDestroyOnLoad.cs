using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public GameObject[] objects;
    
    void Awake()
    {
        foreach (GameObject element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }

}
