using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterLock : MonoBehaviour
{
    //public GameObject[] Slot1;
    //public GameObject[] Slot2;
    //public GameObject[] Slot3;
    //public GameObject[] Slot4;
    //public GameObject[] Slot5;
    //public GameObject[] Slot6;

    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;
    public GameObject Slot5;
    public GameObject Slot6;

    private Animator Slot1Anim;
    private Animator Slot2Anim;
    private Animator Slot3Anim;
    private Animator Slot4Anim;
    private Animator Slot5Anim;
    private Animator Slot6Anim;

    private int currentSlot1;
    private int currentSlot2;
    private int currentSlot3;
    private int currentSlot4;
    private int currentSlot5;
    private int currentSlot6;

    //public GameObject drawer;
    //public GameObject drawerText;
    public GameObject pinBackground;
    public GameObject pinSlots;
    public GameObject lockPanel;

    public GameObject letterCHEATBtn;
    public GameObject pinCHEATBtn;

    private AudioSource lockClickSource;
    public AudioClip lockClickClip;

    private Coroutine coroutine;
    private Coroutine slot1Cor;
    private Coroutine slot2Cor;
    private Coroutine slot3Cor;
    private Coroutine slot4Cor;
    private Coroutine slot5Cor;
    private Coroutine slot6Cor;
    private bool puzzleComplete;

    public GameObject winPar;
    public GameObject particlePos;
    private GameObject tempWinEffect;
    private bool transitioningSlot1;
    private bool transitioningSlot2;
    private bool transitioningSlot3;
    private bool transitioningSlot4;
    private bool transitioningSlot5;
    private bool transitioningSlot6;

    public GameObject backgroundPlaceholder;

    // Start is called before the first frame update
    void Start()
    {
        Slot1Anim = Slot1.GetComponent<Animator>();
        Slot2Anim = Slot2.GetComponent<Animator>();
        Slot3Anim = Slot3.GetComponent<Animator>();
        Slot4Anim = Slot4.GetComponent<Animator>();
        Slot5Anim = Slot5.GetComponent<Animator>();
        Slot6Anim = Slot6.GetComponent<Animator>();

        lockClickSource = GetComponent<AudioSource>();
        currentSlot1 = 0;
        currentSlot2 = 0;
        currentSlot3 = 0;
        currentSlot4 = 0;
        currentSlot5 = 0;
        currentSlot6 = 0;
        puzzleComplete = false;
        transitioningSlot1 = false;
        transitioningSlot2 = false;
        transitioningSlot3 = false;
        transitioningSlot4 = false;
        transitioningSlot5 = false;
        transitioningSlot6 = false;
    }

    // Update is called once per frame
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
                        Slot1Anim.SetBool("Go to Next State", true);
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
                        Slot2Anim.SetBool("Go to Next State", true);
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
                        Slot3Anim.SetBool("Go to Next State", true);
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
                        Slot4Anim.SetBool("Go to Next State", true);
                        transitioningSlot4 = true;
                        lockClickSource.pitch = Random.Range(0.8f, 1f);
                        lockClickSource.PlayOneShot(lockClickClip, 1f);
                        slot4Cor = StartCoroutine(LockSlot4WaitTime());
                        currentSlot4 = CheckSlotNum(currentSlot4);
                    }
                    break;
                case 5:
                    if (!transitioningSlot5)
                    {
                        currentSlot5++;
                        Slot5Anim.SetBool("Go to Next State", true);
                        transitioningSlot5 = true;
                        lockClickSource.pitch = Random.Range(0.8f, 1f);
                        lockClickSource.PlayOneShot(lockClickClip, 1f);
                        slot5Cor = StartCoroutine(LockSlot5WaitTime());
                        currentSlot5 = CheckSlotNum(currentSlot5);
                    }
                    break;
                case 6:
                    if (!transitioningSlot6)
                    {
                        currentSlot6++;
                        Slot6Anim.SetBool("Go to Next State", true);
                        transitioningSlot6 = true;
                        lockClickSource.pitch = Random.Range(0.8f, 1f);
                        lockClickSource.PlayOneShot(lockClickClip, 1f);
                        slot6Cor = StartCoroutine(LockSlot6WaitTime());
                        currentSlot6 = CheckSlotNum(currentSlot6);
                    }
                    break;
                default:
                    Debug.Log("incorrect");
                    break;
            }

            if (currentSlot1 == 1 && currentSlot2 == 2 && currentSlot3 == 3 && currentSlot4 == 4 && currentSlot5 == 5 && currentSlot6 == 1)
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
        if (numToCheck == 6)
            numToCheck = 0;

        return numToCheck;
    }

    public void ResetLock()
    {
        currentSlot1 = 0;
        currentSlot2 = 0;
        currentSlot3 = 0;
        currentSlot4 = 0;
        currentSlot5 = 0;
        currentSlot6 = 0;
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
        pinBackground.SetActive(true);
        pinSlots.SetActive(true);
        lockPanel.SetActive(false);
        //letterCHEATBtn.SetActive(false);
        //pinCHEATBtn.SetActive(true);
        Destroy(tempWinEffect);
        backgroundPlaceholder.SetActive(true);
    }

    private IEnumerator LockSlot1WaitTime()
    {
        yield return new WaitForSeconds(0.54f);
        Slot1Anim.SetBool("Go to Next State", false);
        transitioningSlot1 = false;
    }

    private IEnumerator LockSlot2WaitTime()
    {
        yield return new WaitForSeconds(0.54f);
        Slot2Anim.SetBool("Go to Next State", false);
        transitioningSlot2 = false;
    }

    private IEnumerator LockSlot3WaitTime()
    {
        yield return new WaitForSeconds(0.54f);
        Slot3Anim.SetBool("Go to Next State", false);
        transitioningSlot3 = false;
    }

    private IEnumerator LockSlot4WaitTime()
    {
        yield return new WaitForSeconds(0.54f);
        Slot4Anim.SetBool("Go to Next State", false);
        transitioningSlot4 = false;
    }

    private IEnumerator LockSlot5WaitTime()
    {
        yield return new WaitForSeconds(0.54f);
        Slot5Anim.SetBool("Go to Next State", false);
        transitioningSlot5 = false;
    }

    private IEnumerator LockSlot6WaitTime()
    {
        yield return new WaitForSeconds(0.54f);
        Slot6Anim.SetBool("Go to Next State", false);
        transitioningSlot6 = false;
    }
}
