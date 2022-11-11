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

    // Start is called before the first frame update
    void Start()
    {
        puzzleComplete = false;
        lampSource = GetComponent<AudioSource>();
        correctInput = new string[5];
        userInput = new string[5];

        correctInput[0] = "dot";
        correctInput[1] = "dot";
        correctInput[2] = "dash";
        correctInput[3] = "dash";
        correctInput[4] = "dot";

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
            if(currentSequenceInput == 5)
            {
                puzzleComplete = true;
                otherLamp.SetActive(false);
                theLamp.SetActive(false);
                dotButton.SetActive(false);
                dashButton.SetActive(false);
                windowHint.SetActive(true);
                hint.SetActive(false);
                lampSource.PlayOneShot(win, 1f);

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
        puzzleComplete = true;
        otherLamp.SetActive(false);
        theLamp.SetActive(false);
        dotButton.SetActive(false);
        dashButton.SetActive(false);
        windowHint.SetActive(true);
        hint.SetActive(false);
        lampSource.PlayOneShot(win, 1f);
    }
}
