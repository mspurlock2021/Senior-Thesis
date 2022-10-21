using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicContinuous : MonoBehaviour
{
    public static MusicContinuous instance;
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
