using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampStartStop : MonoBehaviour
{
    public GameObject Light;
    public Transform lampPos;
    public GameObject StartButton;
    public GameObject StopButton;
    public GameObject currentLight;
    public bool lightGoing;
   

    private void Start()
    {
        lightGoing = false;
    }
    public void StartLamp()
    {
        currentLight = Instantiate(Light, lampPos);
        lightGoing = true;
        StartButton.SetActive(false);
        StopButton.SetActive(true);

    }

    public void StopLamp()
    {
        Destroy(currentLight);
        lightGoing = false;
        StopButton.SetActive(false);
        StartButton.SetActive(true);
    }

    //public override void onStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}
}
