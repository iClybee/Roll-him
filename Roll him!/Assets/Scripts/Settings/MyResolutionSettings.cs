using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyResolutionSettings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;


        
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) 
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        LoadSettings(currentResolutionIndex);
    }

    public void SetFullscreen(bool isFullscreen)
        {
         Screen.fullScreen = isFullscreen;
        }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SaveSettigs()
    {
        PlayerPrefs.SetInt("ResolutionPref", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPref", System.Convert.ToInt32(Screen.fullScreen));
    }

    private void LoadSettings(int currentResolutionIndex)
    {

        if (PlayerPrefs.HasKey("ResolutionPref"))
        {
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPref");
        }

        else
            resolutionDropdown.value = currentResolutionIndex;

        if (PlayerPrefs.HasKey("FullscreenPref"))
        {
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPref"));
        }

        else
            Screen.fullScreen = true;
    }
}