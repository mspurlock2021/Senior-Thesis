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
    public Animator level2Anim;
    public AudioSource lampSource;
    public AudioClip buttonClicked;
   

    private void Start()
    {
        lightGoing = false;
    }
    public void StartLamp()
    {
        lampSource.pitch = Random.Range(0.8f, 1f);
        lampSource.PlayOneShot(buttonClicked, 1f);
        currentLight = Instantiate(Light, lampPos);
        lightGoing = true;
        StartButton.SetActive(false);
        StopButton.SetActive(true);

    }

    public void StopLamp()
    {
        lampSource.pitch = Random.Range(0.8f, 1f);
        lampSource.PlayOneShot(buttonClicked, 1f);
        Destroy(currentLight);
        lightGoing = false;
        StopButton.SetActive(false);
        StartButton.SetActive(true);
    }

    public void PuzzleComplete()
    {
        Destroy(currentLight);
        lightGoing = false;
        StopButton.SetActive(false);
        StartButton.SetActive(false);
        level2Anim.SetBool("Lamp Complete", true);

    }

    //public override void onStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}
}
