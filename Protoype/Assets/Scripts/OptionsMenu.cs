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

    public TMP_ColorGradient[] gradients;
    public TMP_FontAsset[] fonts;
 
    public TMP_Dropdown resolutionDropdown, textColourDropdown, fontDropdown;
    public Slider playerHealth, attackSpeed, turnTime;
    public float speed;
    public int health, time;

    public TextMeshProUGUI[] allText;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        int currentGradient = 0;
        int currentFont = 0;

        for (int i = 0; i < resolutions.Length; i++)
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

        allText = Resources.FindObjectsOfTypeAll(typeof(TextMeshProUGUI)) as TextMeshProUGUI[];
        textColourDropdown.value = currentGradient;
        fontDropdown.value = currentFont;
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

    public void SetTextFont(int font)
    {
        foreach (TextMeshProUGUI text in allText)
        {
            text.font = fonts[font];
        }
        PlayerPrefs.SetInt("font", font);
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

    public void SetTextColour(int gradientIndex)
    {
        foreach(TextMeshProUGUI text in allText)
        {
            text.colorGradientPreset = gradients[gradientIndex];
        }

        PlayerPrefs.SetInt("gradient", gradientIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ExitGameplayMenu()
    {
        SetGameplay();
    }

    public void ExitDisplayMenu()
    {
        PlayerPrefs.Save();
    }
}
