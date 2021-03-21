using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionDropdown;
    public AudioMixer mixer;
    private float currentVolume;
    
    Resolution[] resolutions;
    void Start () {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> tmp = new List<string>();

        int currentResolution = 0;

        for (int i = 0 ; i< resolutions.Length; i++)
        {
            if (resolutions[i].height >= 720) 
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                tmp.Add(option);

                if (resolutions[i].height == Screen.currentResolution.height && 
                    resolutions[i].width == Screen.currentResolution.width) currentResolution = i;
            }
        }

        resolutionDropdown.AddOptions(tmp);
        resolutionDropdown.value = currentResolution;
        resolutionDropdown.RefreshShownValue();
    }


    public void SetVolume (float volume) 
    {
        float newVol = 11.18f * Mathf.Sqrt(volume / 3) - 57.8f;

        mixer.SetFloat("Volume", newVol);
        currentVolume = newVol;
    }

    public void SetQuality (int index) 
    {
        QualitySettings.SetQualityLevel(index);
        
    }

    public float GetVolume () {
        return currentVolume;
    }

    public void SetFullscreen (bool set)
    {
        Screen.fullScreen = set;
    }

    public void SetResolution (int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
