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
        MusicVolume = 0.2f;
        SEVolume = 0.2f;
        MusicMixer.SetFloat("MusicVol", Mathf.Log10(MusicVolume) * 20);
        SEMixer.SetFloat("SEVolume", Mathf.Log10(SEVolume) * 20);
        
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
