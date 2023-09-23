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
    [SerializedDictionary("SoundName", "Sound")]
    [SerializeField] SerializedDictionary<string, AudioSource> _soundsSources;


    [Space(20)]
    [Header("====Debugs====")]
    [SerializeField] AudioSettings _audioSettings;


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
            foreach(var dictionaryElement in _soundsSources)
            {
                //AudioSource soundSource = dictionaryElement.Value;
                //soundSource.volume = 0.5f;
                dictionaryElement.Value.volume = _audioSettings.SoundsVolume;
            }

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
        foreach (var dictionaryElement in _soundsSources)
            dictionaryElement.Value.volume = _audioSettings.SoundsVolume;
        SaveSettings();
    }

    public void PlaySound(string soundName)
    {
        _soundsSources[soundName].Play();
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
        foreach (var dictionaryElement in _soundsSources)
            dictionaryElement.Value.volume = _audioSettings.SoundsVolume;

        _musicSlider.value = _audioSettings.MusicVolume;
        _soundsSlider.value = _audioSettings.SoundsVolume;
    }
}
