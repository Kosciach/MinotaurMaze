using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [Header("====References====")]
    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioSource _soundsSource;
    

    [Space(20)]
    [Header("====Debugs====")]
    [SerializeField] AudioSettings _audioSettings;


    [Space(20)]
    [Header("====Settings====")]
    [SerializedDictionary("SoundName", "Sound")]
    [SerializeField] SerializedDictionary<string, AudioClip> _sounds;


    private Slider _musicSlider;
    private Slider _soundsSlider;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        _musicSlider = GameObject.FindGameObjectWithTag("MusicSlider").GetComponent<Slider>();
        _soundsSlider = GameObject.FindGameObjectWithTag("SoundsSlider").GetComponent<Slider>();

        if (File.Exists(Application.dataPath + "/AudioSettings.json")) LoadSettings();
        else
        {
            _audioSettings.MusicVolume = 0.5f;
            _audioSettings.SoundsVolume = 0.5f;
            SaveSettings();

            _musicSource.volume = _audioSettings.MusicVolume;
            _soundsSource.volume = _audioSettings.SoundsVolume;

            _musicSlider.value = _audioSettings.MusicVolume;
            _soundsSlider.value = _audioSettings.SoundsVolume;
        }
    }


    public void ChangeMusicVolume(Slider slider)
    {
        _audioSettings.MusicVolume = slider.value;
        _musicSource.volume = _audioSettings.MusicVolume;
        SaveSettings();
    }
    public void ChangeSoundVolume(Slider slider)
    {
        _audioSettings.SoundsVolume = slider.value;
        _soundsSource.volume = _audioSettings.SoundsVolume;
        SaveSettings();
    }

    public void PlaySound(string soundName)
    {
        _soundsSource.clip = _sounds[soundName];
        _soundsSource.Play();
    }


    private void SaveSettings()
    {
        string jsonAudioSettings = JsonUtility.ToJson(_audioSettings);
        File.WriteAllText(Application.dataPath + "/AudioSettings.json", jsonAudioSettings);
    }
    private void LoadSettings()
    {
        string jsonAudioSettings = File.ReadAllText(Application.dataPath + "/AudioSettings.json");
        _audioSettings = JsonUtility.FromJson<AudioSettings>(jsonAudioSettings);

        _musicSource.volume = _audioSettings.MusicVolume;
        _soundsSource.volume = _audioSettings.SoundsVolume;

        _musicSlider.value = _audioSettings.MusicVolume;
        _soundsSlider.value = _audioSettings.SoundsVolume;
    }
}
