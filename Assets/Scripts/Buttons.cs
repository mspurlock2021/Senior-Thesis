using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public string scene;
    public AudioSource testSource;
    public AudioClip testClip;
    public AudioClip buttonClicked;
    private Coroutine coroutine;
    private Coroutine coroutine2;

    private void Start()
    {
        //testSource = this.GetComponent<AudioSource>();
    }

    public void LoadLevel()
    {
        testSource.pitch = Random.Range(0.8f, 1f);
        testSource.PlayOneShot(buttonClicked, 1f);
        coroutine = StartCoroutine(WaitTime());
    }

    public void Quit()
    {
        testSource.pitch = Random.Range(0.8f, 1f);
        testSource.PlayOneShot(buttonClicked, 1f);
        coroutine2 = StartCoroutine(WaitTime2());
    }

    public void TestSound()
    {
        testSource.PlayOneShot(testClip, 1.0f);
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(scene);
    }

    private IEnumerator WaitTime2()
    {
        yield return new WaitForSeconds(0.1f);
        Application.Quit();
    }
}
