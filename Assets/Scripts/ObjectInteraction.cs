using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject panel;
    public GameObject gameManager;
    private CameraScroll camScroll;
    //private bool panelOpen;

    void Start()
    {
        //camScroll = gameManager.GetComponent<CameraScroll>();
    }

    public void turnOnPanel()
    {
        if (!gameManager.GetComponent<PanelActive>().panelOn)
        {
            gameManager.GetComponent<CameraScroll>().canScroll = false;
            panel.SetActive(true);
            gameManager.GetComponent<PanelActive>().panelOn = true;
        }
        //Debug.Log(panelOpen);
    }

    public void turnOffPanel()
    {
        if (gameManager.GetComponent<PanelActive>().panelOn)
        {
            gameManager.GetComponent<CameraScroll>().canScroll = true;
            panel.SetActive(false);
            gameManager.GetComponent<PanelActive>().panelOn = false;
        }
    }
}
