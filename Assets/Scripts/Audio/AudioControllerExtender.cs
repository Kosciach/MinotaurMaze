using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControllerExtender : MonoBehaviour
{
    public void ChangeMusicVolume(Slider slider)
    {
        AudioController.Instance.ChangeMusicVolume(slider);
    }
    public void ChangeSoundVolume(Slider slider)
    {
        AudioController.Instance.ChangeSoundVolume(slider);
    }
    public void PlayButtonSound(string soundName)
    {
        AudioController.Instance.PlaySound(soundName);
    }
}
