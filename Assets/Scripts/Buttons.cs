using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public string scene;
    private AudioSource testSource;
    public AudioClip testClip;

    private void Start()
    {
        testSource = this.GetComponent<AudioSource>();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void TestSound()
    {
        testSource.PlayOneShot(testClip, 1.0f);
    }
}
