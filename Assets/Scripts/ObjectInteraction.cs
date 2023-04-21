using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject panel;
    public GameObject gameManager;
    private CameraScroll camScroll;
    public GameObject inventory;
    public AudioClip openPanel;
    public AudioClip closePanel;
    private AudioSource openPanelSource;
    private Coroutine coroutine;

    //private bool panelOpen;

    void Start()
    {
        openPanelSource = GetComponent<AudioSource>();
        //camScroll = gameManager.GetComponent<CameraScroll>();
    }

    private void Awake()
    {
        openPanelSource = GetComponent<AudioSource>();
    }

    public void turnOnPanel()
    {
        if (!gameManager.GetComponent<PanelActive>().panelOn)
        {
            //gameManager.GetComponent<CameraScroll>().canScroll = false;
            panel.SetActive(true);
            inventory.transform.SetAsLastSibling();
            gameManager.GetComponent<PanelActive>().panelOn = true;
            openPanelSource.pitch = Random.Range(0.8f, 1f);
            openPanelSource.PlayOneShot(openPanel, 1f);
        }
        //Debug.Log(panelOpen);
    }

    public void turnOffPanel()
    {
        if (gameManager.GetComponent<PanelActive>().panelOn)
        {
            //gameManager.GetComponent<CameraScroll>().canScroll = true;
            openPanelSource.pitch = Random.Range(0.8f, 1f);
            openPanelSource.PlayOneShot(closePanel, 1f);
            coroutine = StartCoroutine(WaitTime());
        }
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.1f);
        panel.SetActive(false);
        gameManager.GetComponent<PanelActive>().panelOn = false;
    }
}
