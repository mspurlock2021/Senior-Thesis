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
    public void PauseButtonPressed()
    {
        this.GetComponent<PanelActive>().panelOn = true;
        this.GetComponent<CameraScroll>().canScroll = false;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeButtonPressed()
    {
        this.GetComponent<PanelActive>().panelOn = false;
        this.GetComponent<CameraScroll>().canScroll = true;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void RestartButtonPressed()
    {
        this.GetComponent<PanelActive>().panelOn = false;
        this.GetComponent<CameraScroll>().canScroll = true;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        if (SceneManager.GetActiveScene().name == "Level 1")
            MusicMixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVol")) * 20);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuPressed()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
            MusicMixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVol")) * 20);
        SceneManager.LoadScene("Main Menu");
    }

    public void SettingsMenuPressed()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void GoBackSettings()
    {
        pausePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}
