using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionDropdown;
    public AudioMixer mixer;
    private float currentVolume = 0;
    
    Resolution[] resolutions;
    void Start () {
        BrackeysResolution();
    }

    void AprilResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> tmp = MakeResolutions();

        string screenRes = Screen.currentResolution.width+"x"+Screen.currentResolution.height;
        int currentResolution = 0;

        for (int i = 0; i< tmp.Count; i++)
        {
            string test = tmp[i];
            if (test.Equals(screenRes)) currentResolution = i;
        }

        resolutionDropdown.AddOptions(tmp);
        resolutionDropdown.value = currentResolution;
        resolutionDropdown.RefreshShownValue();
    }

    void BrackeysResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        
        int currentResolution = 0;

        for (int i = 0; i< resolutions.Length; i++)
        {
            string test = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(test);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolution = i;
                }
        }

        resolutionDropdown.AddOptions(options);
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


    List<string> MakeResolutions()
    {
        List<string> list = new List<string>();
        list.Add(16+"x"+9);
        list.Add(16+"x"+10);
        list.Add(256+"x"+144);
        list.Add(640+"x"+360);
        list.Add(640+"x"+400);
        list.Add(800+"x"+450);
        list.Add(854+"x"+480);
        list.Add(960+"x"+600);
        list.Add(1280+"x"+720);
        list.Add(1440+"x"+900);
        list.Add(1600+"x"+900);
        list.Add(1680+"x"+1050);
        list.Add(1920+"x"+1080);
        list.Add(1920+"x"+1200);
        list.Add(2048+"x"+1152);
        list.Add(2560+"x"+1440);
        list.Add(2560+"x"+1600);
        list.Add(3840+"x"+2160);

        return list;
    }


}
