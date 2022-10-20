using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
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

    public void MainMenuPressed()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
