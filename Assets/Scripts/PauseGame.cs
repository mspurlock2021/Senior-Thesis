using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseGame : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject settingsPanel;
    public AudioMixer MusicMixer;
    private AudioSource audioSource;
    public AudioClip buttonClicked;
    private Coroutine coroutine;
    private Coroutine coroutine2;
    public AudioClip testSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PauseButtonPressed()
    {
        audioSource.pitch = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(buttonClicked, 1f);
        this.GetComponent<PanelActive>().pausePanelOn = true;
        //this.GetComponent<CameraScroll>().canScroll = false;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeButtonPressed()
    {
        audioSource.pitch = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(buttonClicked, 1f);
        this.GetComponent<PanelActive>().pausePanelOn = false;
        //this.GetComponent<CameraScroll>().canScroll = true;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void RestartButtonPressed()
    {
        audioSource.pitch = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(buttonClicked, 1f);
        coroutine = StartCoroutine(WaitTime());
    }

    public void MainMenuPressed()
    {
        audioSource.pitch = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(buttonClicked, 1f);
        coroutine2 = StartCoroutine(WaitTime2());
    }

    public void SettingsMenuPressed()
    {
        audioSource.pitch = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(buttonClicked, 1f);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void GoBackSettings()
    {
        audioSource.pitch = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(buttonClicked, 1f);
        pausePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void TestSound()
    {
        audioSource.PlayOneShot(testSound, 1.0f);
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<PanelActive>().pausePanelOn = false;
        //this.GetComponent<CameraScroll>().canScroll = true;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        if (SceneManager.GetActiveScene().name == "Level 1")
            MusicMixer.SetFloat("MusicVol", Mathf.Log10(GameObject.Find("Music").GetComponent<MusicContinuous>().MusicVolume) * 20);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator WaitTime2()
    {
        yield return new WaitForSeconds(0.1f);
        if (SceneManager.GetActiveScene().name == "Level 1")
            MusicMixer.SetFloat("MusicVol", Mathf.Log10(GameObject.Find("Music").GetComponent<MusicContinuous>().MusicVolume) * 20);
        SceneManager.LoadScene("Main Menu");
    }
}
