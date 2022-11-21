using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicContinuous : MonoBehaviour
{
    public static MusicContinuous instance;
    public float MusicVolume;
    public float SEVolume;
    public AudioMixer MusicMixer;
    public AudioMixer SEMixer;


    private void Start()
    {
        if (PlayerPrefs.GetFloat("MusicVolume") < 1.00001f && PlayerPrefs.GetFloat("MusicVolume") > 0f)
            MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
        else
        MusicVolume = 0.2f;

        if (PlayerPrefs.GetFloat("SEVolume") < 1.00001f && PlayerPrefs.GetFloat("SEVolume") > 0f)
            SEVolume = PlayerPrefs.GetFloat("SEVolume");
        else
            SEVolume = 0.2f;
        MusicMixer.SetFloat("MusicVol", Mathf.Log10(MusicVolume) * 20);
        SEMixer.SetFloat("SEVol", Mathf.Log10(SEVolume) * 20);
        
    }
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
