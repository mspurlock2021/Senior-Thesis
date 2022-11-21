using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject[] Slot1;
    public GameObject[] Slot2;
    public GameObject[] Slot3;
    public GameObject[] Slot4;

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
    private bool puzzleComplete;

    public ParticleSystem winPar;
    public GameObject particlePos;

    // Start is called before the first frame update
    void Start()
    {
        lockClickSource = GetComponent<AudioSource>();
        currentSlot1 = 0;
        currentSlot2 = 0;
        currentSlot3 = 0;
        currentSlot4 = 0;
        puzzleComplete = false;
    }

    // Update is called once per frame
    public void LockNumClicked(int LockSlot)
    {
        if (!puzzleComplete)
        {
            switch (LockSlot)
            {
                case 1:
                    Slot1[currentSlot1].SetActive(false);
                    currentSlot1++;
                    currentSlot1 = CheckSlotNum(currentSlot1);
                    Slot1[currentSlot1].SetActive(true);
                    break;
                case 2:
                    Slot2[currentSlot2].SetActive(false);
                    currentSlot2++;
                    currentSlot2 = CheckSlotNum(currentSlot2);
                    Slot2[currentSlot2].SetActive(true);
                    break;
                case 3:
                    Slot3[currentSlot3].SetActive(false);
                    currentSlot3++;
                    currentSlot3 = CheckSlotNum(currentSlot3);
                    Slot3[currentSlot3].SetActive(true);
                    break;
                case 4:
                    Slot4[currentSlot4].SetActive(false);
                    currentSlot4++;
                    currentSlot4 = CheckSlotNum(currentSlot4);
                    Slot4[currentSlot4].SetActive(true);
                    break;
                default:
                    Debug.Log("incorrect");
                    break;
            }


            lockClickSource.pitch = Random.Range(0.8f, 1f);
            lockClickSource.PlayOneShot(lockClickClip, 1f);

            if (currentSlot1 == 5 && currentSlot2 == 6 && currentSlot3 == 9 && currentSlot4 == 0)
            {
                Instantiate(winPar, particlePos.transform.position, Quaternion.identity);
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
        Slot1[currentSlot1].SetActive(false);
        Slot2[currentSlot2].SetActive(false);
        Slot3[currentSlot3].SetActive(false);
        Slot4[currentSlot4].SetActive(false);
        currentSlot1 = 0;
        currentSlot2 = 0;
        currentSlot3 = 0;
        currentSlot4 = 0;
        Slot1[currentSlot1].SetActive(true);
        Slot2[currentSlot2].SetActive(true);
        Slot3[currentSlot3].SetActive(true);
        Slot4[currentSlot4].SetActive(true);
    }

    public void CHEAT()
    {
        Instantiate(winPar, particlePos.transform.position, Quaternion.identity);
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
    }
}

