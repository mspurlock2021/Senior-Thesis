using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterLock : MonoBehaviour
{
    public GameObject[] Slot1;
    public GameObject[] Slot2;
    public GameObject[] Slot3;
    public GameObject[] Slot4;
    public GameObject[] Slot5;
    public GameObject[] Slot6;

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

    // Start is called before the first frame update
    void Start()
    {
        lockClickSource = GetComponent<AudioSource>();
        currentSlot1 = 0;
        currentSlot2 = 0;
        currentSlot3 = 0;
        currentSlot4 = 0;
        currentSlot5 = 0;
        currentSlot6 = 0;
    }

    // Update is called once per frame
    public void LockNumClicked(int LockSlot)
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
            default:
                Debug.Log("incorrect");
                break;
        }


        lockClickSource.pitch = Random.Range(0.8f, 1f);
        lockClickSource.PlayOneShot(lockClickClip, 0.1f);

        if (currentSlot1 == 1 && currentSlot2 == 2 && currentSlot3 == 3 && currentSlot4 == 4 && currentSlot5 == 5 && currentSlot6 == 1)
        {
            GetComponent<WinSound>().PlayWinSound();
            //drawer.SetActive(true);
            //drawerText.SetActive(true);
            pinBackground.SetActive(true);
            pinSlots.SetActive(true);
            lockPanel.SetActive(false);

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
        Slot1[currentSlot1].SetActive(false);
        Slot2[currentSlot2].SetActive(false);
        Slot3[currentSlot3].SetActive(false);
        Slot4[currentSlot4].SetActive(false);
        Slot5[currentSlot5].SetActive(false);
        Slot6[currentSlot6].SetActive(false);
        currentSlot1 = 0;
        currentSlot2 = 0;
        currentSlot3 = 0;
        currentSlot4 = 0;
        currentSlot5 = 0;
        currentSlot6 = 0;
        Slot1[currentSlot1].SetActive(true);
        Slot2[currentSlot2].SetActive(true);
        Slot3[currentSlot3].SetActive(true);
        Slot4[currentSlot4].SetActive(true);
        Slot5[currentSlot5].SetActive(true);
        Slot6[currentSlot6].SetActive(true);
    }

    public void CHEAT()
    {
        GetComponent<WinSound>().PlayWinSound();
        pinBackground.SetActive(true);
        pinSlots.SetActive(true);
        lockPanel.SetActive(false);
        letterCHEATBtn.SetActive(false);
        pinCHEATBtn.SetActive(true);
    }
}
