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
    private const float MAXIMUM_RADIO_DISTANCE = -1582;
    private const float RADIO_X_VALUE = 585;


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
        //Debug.Log(Mathf.Log10(MusicVolume) * 20);
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


    public void RadioMusic(float currentScreenX)
    {
        float temp = currentScreenX - RADIO_X_VALUE;
        temp /= MAXIMUM_RADIO_DISTANCE;
        temp = Mathf.Abs(temp);
        temp = 1 - temp;
        float halfOfMusicVolume = PlayerPrefs.GetFloat("MusicVolume") / 4;
        MusicMixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume") * temp + halfOfMusicVolume) * 20);
        //Debug.Log(Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume") - halfOfMusicVolume * temp) * 20);
        //Debug.Log(temp);
    }
}
