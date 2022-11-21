using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;

    [SerializeField] private TextMeshProUGUI volumeTextUI = null;

    [SerializeField] private AudioMixer mixer = null;

    [SerializeField] private string exposedParamString = null;

    private void Start()
    {
        if (exposedParamString == "MusicVol")
        {
            SliderForVolume(GameObject.Find("Music").GetComponent<MusicContinuous>().MusicVolume);
            volumeSlider.value = GameObject.Find("Music").GetComponent<MusicContinuous>().MusicVolume;
        }
        else if (exposedParamString == "SEVol")
        {
            SliderForVolume(GameObject.Find("Music").GetComponent<MusicContinuous>().SEVolume);
            volumeSlider.value = GameObject.Find("Music").GetComponent<MusicContinuous>().SEVolume;
        }
    }

    public void SliderForVolume(float volume)
    {
        if (exposedParamString == "MusicVol")
        {
            GameObject.Find("Music").GetComponent<MusicContinuous>().MusicVolume = volume;
            PlayerPrefs.SetFloat("MusicVolume", volume);
        }
        else if (exposedParamString == "SEVol")
        {
            GameObject.Find("Music").GetComponent<MusicContinuous>().SEVolume = volume;
            PlayerPrefs.SetFloat("SEVolume", volume);
        }
        volumeTextUI.text = (volume * 100).ToString("0");
        mixer.SetFloat(exposedParamString, Mathf.Log10(volume) * 20);
    }
}
