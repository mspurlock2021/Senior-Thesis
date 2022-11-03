using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public GameObject theLamp;
    private bool lampSequenceOn;
    private int currentSequenceInput;
    private string[] correctInput;
    private string[] userInput;
    public GameObject dashButton;
    public GameObject dotButton;
    private bool puzzleDone;
    public GameObject windowHint;
    private AudioSource lampSource;
    public AudioClip error;
    public GameObject paper;
    public GameObject hint;
    public AudioClip win;
    public GameObject otherLamp;

    private IEnumerator coroutine; 
    // Start is called before the first frame update
    void Start()
    {
        lampSource = GetComponent<AudioSource>();
        correctInput = new string[5];
        userInput = new string[5];

        correctInput[0] = "dot";
        correctInput[1] = "dot";
        correctInput[2] = "dash";
        correctInput[3] = "dash";
        correctInput[4] = "dot";

        puzzleDone = false;

        currentSequenceInput = 0;
        lampSequenceOn = true;
        LampSequenceOn();
    }

    private void OnEnable()
    {
        lampSequenceOn = true;
        LampSequenceOn();
    }

    private void OnDisable()
    {
        lampSequenceOn = false;
        StopCoroutine(coroutine);
        currentSequenceInput = 0;
    }

    private void LampSequenceOn()
    {
        if (lampSequenceOn)
        {
            //Debug.Log("on");
            coroutine = ActivateLamp();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator ActivateLamp()
    {
        while (lampSequenceOn && !puzzleDone)
        {
            //dot
            theLamp.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            if (!lampSequenceOn)
                break;
            theLamp.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            if (!lampSequenceOn)
                break;

            //dot
            theLamp.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            if (!lampSequenceOn)
                break;
            theLamp.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            if (!lampSequenceOn)
                break;

            //dash
            theLamp.SetActive(true);
            yield return new WaitForSeconds(1f);
            if (!lampSequenceOn)
                break;
            theLamp.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            if (!lampSequenceOn)
                break;

            //dash
            theLamp.SetActive(true);
            yield return new WaitForSeconds(1f);
            if (!lampSequenceOn)
                break;
            theLamp.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            if (!lampSequenceOn)
                break;

            //dot
            theLamp.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            if (!lampSequenceOn)
                break;
            theLamp.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            if (!lampSequenceOn)
                break;

            //wait to start again
            yield return new WaitForSeconds(3f);
            if (!lampSequenceOn)
                break;

        }

    }

    public void turnLampOff()
    {
        lampSequenceOn = false;
        StopCoroutine(coroutine);
    }

    public void turnLampOn()
    {
        lampSequenceOn = true;
        coroutine = ActivateLamp();
        StartCoroutine(coroutine);
    }

    public void DashPressed()
    {
        CheckWin("dash");
    }

    public void DotPressed()
    {
        CheckWin("dot");
    }

    private void CheckWin(string input)
    {
        userInput[currentSequenceInput] = input;

        if (userInput[currentSequenceInput] == correctInput[currentSequenceInput])
        {
            currentSequenceInput++;
            if(currentSequenceInput == 5)
            {
                otherLamp.GetComponent<Lamp>().puzzleDone = true;
                puzzleDone = true;
                dotButton.SetActive(false);
                dashButton.SetActive(false);
                windowHint.SetActive(true);
                hint.SetActive(false);
                lampSource.PlayOneShot(win, 0.2f);

            }
        }
        else
        {
            lampSource.PlayOneShot(error, 1f);
            currentSequenceInput = 0;
        }


    }

    public void PaperCollected()
    {
        paper.SetActive(false);
        hint.SetActive(true);
    }
   
    public void CHEAT()
    {
        otherLamp.GetComponent<Lamp>().puzzleDone = true;
        puzzleDone = true;
        dotButton.SetActive(false);
        dashButton.SetActive(false);
        windowHint.SetActive(true);
        hint.SetActive(false);
        lampSource.PlayOneShot(win, 0.2f);
    }
}
