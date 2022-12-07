using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevel2 : MonoBehaviour
{

    private float timeOfMusic;
    private AudioSource musicObj;
    public AudioClip muffledMusic;
    // Start is called before the first frame update
    void Start()
    {
        musicObj = GameObject.Find("Music").GetComponent<AudioSource>();
        if (musicObj.isPlaying)
        {
            timeOfMusic = musicObj.time;
            musicObj.Stop();
            musicObj.clip = muffledMusic;
            musicObj.Play();
            musicObj.time = timeOfMusic;
        }
        else
        {
            musicObj.clip = muffledMusic;
            musicObj.Play();
            musicObj.time = 0;
        }

    }

}
