using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsPanelScript : MonoBehaviour
{
    public TMP_Dropdown resolutionsDropdown;
    public Resolution[] m_Resolutions;

    public AudioMixer am;

    public GameObject settingspanel;
    
    public void Start()
    {
        m_Resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < m_Resolutions.Length; i++)
        {
            options.Add(m_Resolutions[i].width + "x" + m_Resolutions[i].height);

            if (m_Resolutions[i].height == Screen.height && m_Resolutions[i].width == Screen.width)
                currentResolutionIndex = i;
        }
        
        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Debug.LogWarning(resolutionIndex + " // " + m_Resolutions[resolutionIndex]);
        Resolution resolution = m_Resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Debug.LogWarning(isFullScreen);
        Screen.fullScreen = isFullScreen;
    }

    public void SetVolume(float volume)
    {
        am.SetFloat("volume", volume);
    }

    public void ExitSettings()
    {
        settingspanel.SetActive(false);
    }
}
