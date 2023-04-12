using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public static HealthBar instance;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("il y a plus d'une instance de HealthBar");
            return;
        }

        instance = this;
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
