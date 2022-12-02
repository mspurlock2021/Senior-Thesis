using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinLock : MonoBehaviour
{
    public GameObject[] Slot1;
    public GameObject[] Slot2;
    public GameObject[] Slot3;
    public GameObject[] Slot4;
    public GameObject[] Slot5;
    public GameObject[] Slot6;
    public GameObject[] Slot7;
    public GameObject[] Slot8;

    private int currentSlot1;
    private int currentSlot2;
    private int currentSlot3;
    private int currentSlot4;
    private int currentSlot5;
    private int currentSlot6;
    private int currentSlot7;
    private int currentSlot8;

    public GameObject drawer;
    public GameObject drawerText;
    public GameObject key;
    public GameObject lockPanel;
    public GameObject lockSlots;
    public GameObject refPanel;

    private AudioSource lockClickSource;
    public AudioClip lockClickClip;

    private Coroutine coroutine;
    private bool puzzleComplete;

    public GameObject particlePos;
    public GameObject winPar;
    private GameObject tempWinEffect;

    // Start is called before the first frame update
    void Start()
    {
        puzzleComplete = false;
        lockClickSource = GetComponent<AudioSource>();
        currentSlot1 = 0;
        currentSlot2 = 0;
        currentSlot3 = 0;
        currentSlot4 = 0;
        currentSlot5 = 0;
        currentSlot6 = 0;
        currentSlot7 = 0;
        currentSlot8 = 0;
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
                case 5:
                    Slot5[currentSlot5].SetActive(false);
                    currentSlot5++;
                    currentSlot5 = CheckSlotNum(currentSlot5);
                    Slot5[currentSlot5].SetActive(true);
                    break;
                case 6:
                    Slot6[currentSlot6].SetActive(false);
                    currentSlot6++;
                    currentSlot6 = CheckSlotNum(currentSlot6);
                    Slot6[currentSlot6].SetActive(true);
                    break;
                case 7:
                    Slot7[currentSlot7].SetActive(false);
                    currentSlot7++;
                    currentSlot7 = CheckSlotNum(currentSlot7);
                    Slot7[currentSlot7].SetActive(true);
                    break;
                case 8:
                    Slot8[currentSlot8].SetActive(false);
                    currentSlot8++;
                    currentSlot8 = CheckSlotNum(currentSlot8);
                    Slot8[currentSlot8].SetActive(true);
                    break;
                default:
                    Debug.Log("incorrect");
                    break;
            }


            lockClickSource.pitch = Random.Range(0.8f, 1f);
            lockClickSource.PlayOneShot(lockClickClip, 1f);

            if (currentSlot1 == 0 && currentSlot2 == 1 && currentSlot3 == 2 && currentSlot4 == 3 && currentSlot5 == 0 && currentSlot6 == 3 && currentSlot7 == 2 && currentSlot8 == 2)
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
        if (numToCheck == 4)
            numToCheck = 0;

        return numToCheck;
    }

    public void ResetLock()
    {
        Slot1[currentSlot1].SetActive(false);
        Slot2[currentSlot2].SetActive(false);
        Slot3[currentSlot3].SetActive(false);
        Slot4[currentSlot4].SetActive(false);
        Slot5[currentSlot5].SetActive(false);
        Slot6[currentSlot6].SetActive(false);
        Slot7[currentSlot7].SetActive(false);
        Slot8[currentSlot8].SetActive(false);
        currentSlot1 = 0;
        currentSlot2 = 0;
        currentSlot3 = 0;
        currentSlot4 = 0;
        currentSlot5 = 0;
        currentSlot6 = 0;
        currentSlot7 = 0;
        currentSlot8 = 0;
        Slot1[currentSlot1].SetActive(true);
        Slot2[currentSlot2].SetActive(true);
        Slot3[currentSlot3].SetActive(true);
        Slot4[currentSlot4].SetActive(true);
        Slot5[currentSlot5].SetActive(true);
        Slot6[currentSlot6].SetActive(true);
        Slot7[currentSlot7].SetActive(true);
        Slot8[currentSlot8].SetActive(true);
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
        lockSlots.SetActive(false);
        refPanel.SetActive(true);
        Destroy(tempWinEffect);
    }
}
