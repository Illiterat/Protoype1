using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioConfiguration Config;

    public TMP_Dropdown resolutionDropdown;
    public Slider playerHealth, attackSpeed, turnTime;
    public float speed;
    public int health, time;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetGameplay()
    {
        health = (int)playerHealth.value;
        speed = attackSpeed.value;
        time = (int)turnTime.value;

        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.SetInt("time", time);
        PlayerPrefs.SetFloat("speed", speed);

        PlayerPrefs.Save();
    }

    public void ExitGameplayMenu()
    {
        SetGameplay();
    }

    public void SetMasterVolume (float MasterVolume)
    {
        audioMixer.SetFloat("MasterVolume", MasterVolume);
    }

    public void SetMusicVolume(float MusicVolume)
    {
        audioMixer.SetFloat("MusicVolume", MusicVolume);
    }

    public void SetEffectsVolume(float EffectsVolume)
    {
        audioMixer.SetFloat("EffectsVolume", EffectsVolume);
    }

    public void SetMono(bool Mono)
    {
        if(Mono == true)
        {
            Config.speakerMode = AudioSpeakerMode.Mono;
        }

        if (Mono == false)
        {
            Config.speakerMode = AudioSpeakerMode.Stereo;
        }
    }

    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
