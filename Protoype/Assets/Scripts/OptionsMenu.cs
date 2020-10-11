using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public AudioMixer audioMixer;
    public AudioConfiguration Config;

    public TMP_ColorGradient[] gradients;
    public TMP_FontAsset[] fonts;
 
    public TMP_Dropdown resolutionDropdown, textColourDropdown, fontDropdown;
    public Slider playerHealth, attackSpeed, turnTime;
    public float speed;
    public int health, time, BGOnOffToggle, FXOnOffToggle, ContrastOnOffToggle;
    public static bool GameIsPaused = false;

    public TextMeshProUGUI[] allText;

    Resolution[] resolutions;

    public GameObject pauseMenuUI;

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

        keys.Add("Escape", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Escape", "Escape")));
    }

    public void Update()
    {
        if(Input.GetKeyDown(keys["Escape"]))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
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

   /* public void SetMono(bool Mono)
    {
        if(Mono == true)
        {
            Config.speakerMode = AudioSpeakerMode.Mono;
        }

        if (Mono == false)
        {
            Config.speakerMode = AudioSpeakerMode.Stereo;
        }
    } */

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

    public void ToggleBackground(bool background)
    {
        if(background == true)
        {
            BGOnOffToggle = 1;
        }

        if(background == false)
        {
            BGOnOffToggle = 0;
        }
        PlayerPrefs.SetInt("backgroundToggle", BGOnOffToggle);
    }

    public void ToggleFX (bool FX)
    {
        if (FX == true)
        {
            FXOnOffToggle = 1;
        }

        if (FX == false)
        {
            FXOnOffToggle = 0;
        }
        PlayerPrefs.SetInt("fxToggle", FXOnOffToggle);
    }

    public void ToggleContrast(bool contrast)
    {
        if (contrast == true)
        {
            ContrastOnOffToggle = 1;
        }

        if (contrast == false)
        {
            ContrastOnOffToggle = 0;
        }
        PlayerPrefs.SetInt("contrastToggle", ContrastOnOffToggle);
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
