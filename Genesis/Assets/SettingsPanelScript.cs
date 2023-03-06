using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsPanelScript : MonoBehaviour
{
    public AudioMixer Audio;
    private Resolution[] resolutionlist;
    public TMP_Dropdown drop;
    public GameObject settingsPanel;


    public void Start()
    {
        drop.ClearOptions();
        List<string> option = new List<string>();
        resolutionlist = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height} ).Distinct().ToArray();
        int currentresolutionindex = 0;
        for (int i = 0; i< resolutionlist.Length; i++)
        {
            option.Add(resolutionlist[i].width + "x" + resolutionlist[i].height);
            if (resolutionlist[i].width == Screen.width && resolutionlist[i].height == Screen.height)
                currentresolutionindex = i;
        }
        drop.AddOptions(option);
        drop.value = currentresolutionindex;
        drop.RefreshShownValue();
       
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutionlist[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }



    public void SetFullScreen(bool coche)
    {
        Screen.fullScreen = coche;
    }

    public void SetVolume(float volume)
    {
        Audio.SetFloat("volume", volume);
    }

    
    public void Return()
    {
        settingsPanel.SetActive(false);
    }
}
