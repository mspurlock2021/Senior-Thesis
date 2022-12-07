using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public GameObject theLamp;
    private int currentSequenceInput;
    private string[] correctInput;
    private string[] userInput;
    public GameObject dashButton;
    public GameObject dotButton;
    public GameObject windowHint;
    private AudioSource lampSource;
    public AudioClip error;
    public GameObject paper;
    public GameObject hint;
    public AudioClip win;
    public GameObject otherLamp;
    private bool puzzleComplete;

    private Coroutine coroutine;

    public GameObject winPar;
    public GameObject particlePos;
    private GameObject tempWinEffect;
    public GameObject lockInteractObj;

    // Start is called before the first frame update
    void Start()
    {
        puzzleComplete = false;
        lampSource = GetComponent<AudioSource>();
        correctInput = new string[16];
        userInput = new string[16];

        correctInput[0] = "dot";
        correctInput[1] = "dash";
        correctInput[2] = "dash";
        correctInput[3] = "dot";
        correctInput[4] = "dot";
        correctInput[5] = "dash";
        correctInput[6] = "dot";
        correctInput[7] = "dash";
        correctInput[8] = "dot";
        correctInput[9] = "dot";
        correctInput[10] = "dash";
        correctInput[11] = "dash";
        correctInput[12] = "dash";
        correctInput[13] = "dot";
        correctInput[14] = "dash";
        correctInput[15] = "dash";

        currentSequenceInput = 0;
    }

    public void TurnOffOtherLamp ()
    {
        if(!puzzleComplete)
        otherLamp.SetActive(false);
    }

    public void TurnOnOtherLamp ()
    {
        if(!puzzleComplete)
        otherLamp.SetActive(true);
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
            if(currentSequenceInput == 16)
            {
                tempWinEffect = Instantiate(winPar, particlePos.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
                puzzleComplete = true;
                otherLamp.SetActive(false);
                theLamp.SetActive(false);
                dotButton.SetActive(false);
                dashButton.SetActive(false);
                windowHint.SetActive(true);
                hint.SetActive(false);
                lockInteractObj.SetActive(true);
                lampSource.PlayOneShot(win, 1f);
                coroutine = StartCoroutine(WaitTime());

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
        tempWinEffect = Instantiate(winPar, particlePos.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        puzzleComplete = true;
        otherLamp.SetActive(false);
        theLamp.SetActive(false);
        dotButton.SetActive(false);
        dashButton.SetActive(false);
        windowHint.SetActive(true);
        hint.SetActive(false);
        lockInteractObj.SetActive(true);
        lampSource.PlayOneShot(win, 1f);
        coroutine = StartCoroutine(WaitTime());
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(tempWinEffect);
    }
}
