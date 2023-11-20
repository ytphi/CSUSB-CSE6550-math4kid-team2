using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource backgroundMusicSource;
    public AudioSource soundEffectSource;
    public AudioClip[] music, sound;

    [SerializeField] private Slider backgroundMusicSlider;
    [SerializeField] private Slider soundEffectSlider;

    private static MusicController instance;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject); // Destroy duplicates in subsequent scenes
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        if (!PlayerPrefs.HasKey("backgroundMusicVol"))
        {
            PlayerPrefs.SetFloat("backgroundMusicVol", backgroundMusicSlider.value);
            PlayerPrefs.SetFloat("soundEffectVol", soundEffectSlider.value);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void SetBackgroundMusicVolume()
    {
        backgroundMusicSource.volume = backgroundMusicSlider.value;
        Save();
    }

    public void SetSoundEffectVolume()
    {
        soundEffectSource.volume = soundEffectSlider.value;
        Save();
    }

    public void Load()
    {
        backgroundMusicSlider.value = PlayerPrefs.GetFloat("backgroundMusicVol");
        soundEffectSlider.value = PlayerPrefs.GetFloat("soundEffectVol");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("backgroundMusicVol", backgroundMusicSlider.value);
        PlayerPrefs.SetFloat("soundEffectVol", soundEffectSlider.value);
        PlayerPrefs.Save(); // Save is necessary to persist the changes immediately
    }
}
