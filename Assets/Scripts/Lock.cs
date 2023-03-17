using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    //public GameObject[] Slot1;
    //public GameObject[] Slot2;
    //public GameObject[] Slot3;
    //public GameObject[] Slot4;

    public GameObject LockSlot1;
    public GameObject LockSlot2;
    public GameObject LockSlot3;
    public GameObject LockSlot4;

    private Animator LockSlot1Anim;
    private Animator LockSlot2Anim;
    private Animator LockSlot3Anim;
    private Animator LockSlot4Anim;


    private int currentSlot1;
    private int currentSlot2;
    private int currentSlot3;
    private int currentSlot4;

    public GameObject drawer;
    public GameObject drawerText;
    public GameObject key;
    public GameObject lockPanel;

    private AudioSource lockClickSource;
    public AudioClip lockClickClip;

    private Coroutine coroutine;
    private Coroutine slot1Cor;
    private Coroutine slot2Cor;
    private Coroutine slot3Cor;
    private Coroutine slot4Cor;
    private bool puzzleComplete;

    public GameObject winPar;
    public GameObject particlePos;
    private GameObject tempWinEffect;
    private bool transitioningSlot1;
    private bool transitioningSlot2;
    private bool transitioningSlot3;
    private bool transitioningSlot4;

    // Start is called before the first frame update
    void Start()
    {
        LockSlot1Anim = LockSlot1.GetComponent<Animator>();
        LockSlot2Anim = LockSlot2.GetComponent<Animator>();
        LockSlot3Anim = LockSlot3.GetComponent<Animator>();
        LockSlot4Anim = LockSlot4.GetComponent<Animator>();

        lockClickSource = GetComponent<AudioSource>();
        currentSlot1 = 0;
        currentSlot2 = 0;
        currentSlot3 = 0;
        currentSlot4 = 0;
        puzzleComplete = false;
        transitioningSlot1 = false;
        transitioningSlot2 = false;
        transitioningSlot3 = false;
        transitioningSlot4 = false;
    }

    public void LockNumClicked(int LockSlot)
    {
        if (!puzzleComplete)
        {
            switch (LockSlot)
            {
                case 1:
                    if (!transitioningSlot1)
                    {
                        currentSlot1++;
                        LockSlot1Anim.SetBool("Go to Next State", true);
                        transitioningSlot1 = true;
                        lockClickSource.pitch = Random.Range(0.8f, 1f);
                        lockClickSource.PlayOneShot(lockClickClip, 1f);
                        slot1Cor = StartCoroutine(LockSlot1WaitTime());
                        currentSlot1 = CheckSlotNum(currentSlot1);
                    }
                    break;
                case 2:
                    if (!transitioningSlot2)
                    {
                        currentSlot2++;
                        LockSlot2Anim.SetBool("Go to Next State", true);
                        transitioningSlot2 = true;
                        lockClickSource.pitch = Random.Range(0.8f, 1f);
                        lockClickSource.PlayOneShot(lockClickClip, 1f);
                        slot2Cor = StartCoroutine(LockSlot2WaitTime());
                        currentSlot2 = CheckSlotNum(currentSlot2);
                    }
                    break;
                case 3:
                    if (!transitioningSlot3)
                    {
                        currentSlot3++;
                        LockSlot3Anim.SetBool("Go to Next State", true);
                        transitioningSlot3 = true;
                        lockClickSource.pitch = Random.Range(0.8f, 1f);
                        lockClickSource.PlayOneShot(lockClickClip, 1f);
                        slot3Cor = StartCoroutine(LockSlot3WaitTime());
                        currentSlot3 = CheckSlotNum(currentSlot3);
                    }
                    break;
                case 4:
                    if (!transitioningSlot4)
                    {
                        currentSlot4++;
                        LockSlot4Anim.SetBool("Go to Next State", true);
                        transitioningSlot4 = true;
                        lockClickSource.pitch = Random.Range(0.8f, 1f);
                        lockClickSource.PlayOneShot(lockClickClip, 1f);
                        slot4Cor = StartCoroutine(LockSlot4WaitTime());
                        currentSlot4 = CheckSlotNum(currentSlot4);
                    }
                    break;
                default:
                    Debug.Log("incorrect");
                    break;
            }

            if (currentSlot1 == 5 && currentSlot2 == 6 && currentSlot3 == 9 && currentSlot4 == 0)
            {
                tempWinEffect = Instantiate(winPar, particlePos.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
                puzzleComplete = true;
                GetComponent<WinSound>().PlayWinSound();
                coroutine = StartCoroutine(WaitTime());
            }
        }
    }

    private int CheckSlotNum(int numToCheck)
    {
        if (numToCheck == 10)
            numToCheck = 0;

        return numToCheck;
    }

    public void ResetLock()
    {
        currentSlot1 = 0;
        currentSlot2 = 0;
        currentSlot3 = 0;
        currentSlot4 = 0;
    }

    public void CHEAT()
    {
        tempWinEffect = Instantiate(winPar, particlePos.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        puzzleComplete = true;
        GetComponent<WinSound>().PlayWinSound();
        coroutine = StartCoroutine(WaitTime());
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.5f);
        drawer.SetActive(true);
        drawerText.SetActive(true);
        key.SetActive(true);
        lockPanel.SetActive(false);
        Destroy(tempWinEffect);
    }

    private IEnumerator LockSlot1WaitTime()
    {
        yield return new WaitForSeconds(0.75f);
        LockSlot1Anim.SetBool("Go to Next State", false);
        transitioningSlot1 = false;
    }

    private IEnumerator LockSlot2WaitTime()
    {
        yield return new WaitForSeconds(0.75f);
        LockSlot2Anim.SetBool("Go to Next State", false);
        transitioningSlot2 = false;
    }

    private IEnumerator LockSlot3WaitTime()
    {
        yield return new WaitForSeconds(0.75f);
        LockSlot3Anim.SetBool("Go to Next State", false);
        transitioningSlot3 = false;
    }

    private IEnumerator LockSlot4WaitTime()
    {
        yield return new WaitForSeconds(0.75f);
        LockSlot4Anim.SetBool("Go to Next State", false);
        transitioningSlot4 = false;
    }
}

