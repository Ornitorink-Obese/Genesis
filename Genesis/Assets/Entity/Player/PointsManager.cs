using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;
    public Slider slider;

    public int good;
    public int bad;
    
    private void Start()
    {
        if (instance != null)
        {
            Debug.Log("une instance existe déjà pour PointsManager");
            return;
        }

        instance = this;

        slider.value = 50;
    }

    private int GetPercentage(int good, int bad)
    {
        if (bad == 0 && good == 0)
            return 50;

        if (bad == 0)
            return 100;
        
        return (good * 100) / (good + bad);
    }

    public void changePoints(int good, int bad)
    {
        Debug.Log($"Good : {good}, Bad : {bad}");
        Debug.Log(GetPercentage(good, bad));
        slider.value = GetPercentage(good, bad);
    }

    public void test()
    {
        changePoints(good, bad);
    }
}
