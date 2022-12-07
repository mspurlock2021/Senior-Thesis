using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenMusic : MonoBehaviour
{
    private AudioSource musicObj;
    // Start is called before the first frame update
    void Start()
    {
        musicObj = GameObject.Find("Music").GetComponent<AudioSource>();
        musicObj.Stop();
    }

}
