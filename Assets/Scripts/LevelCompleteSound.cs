using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteSound : MonoBehaviour
{
    public AudioClip win;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(win, 1f);
    }

}
