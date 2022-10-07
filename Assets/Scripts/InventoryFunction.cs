using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryFunction : MonoBehaviour
{
    public GameObject[] HotBar;

    private bool[] filledSlots = new bool[12];
    private bool OnFirstBar;
    public GameObject posterPanel;
    public GameObject canvasObject;

    private void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            filledSlots[i] = false;
        }

        for (int i = 6; i < 12; i++)
        {
            HotBar[i].SetActive(false);
        }

        OnFirstBar = true;
    }

    public void GrabObject(GameObject ObjToAddToInv)
    {
        for (int i = 0; i < 12; i++)
        { 
            if(filledSlots[i] == false)
            {
                GameObject temp = Instantiate(ObjToAddToInv.GetComponent<PosterPiece>().thisPosterPiece, HotBar[i].transform);
                temp.GetComponent<InvSlot>().CurrentInventorySlot = i;
                Destroy(ObjToAddToInv);
                filledSlots[i] = true;
                break;
            }
        }
    }

    public void SwapInventory()
    {
        if (OnFirstBar)
        {
            for (int i = 0; i < 6; i++)
            {
                HotBar[i].SetActive(false);
            }
            for (int i = 6; i < 12; i++)
            {
                HotBar[i].SetActive(true);
            }
            OnFirstBar = false;
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                HotBar[i].SetActive(true);
            }
            for (int i = 6; i < 12; i++)
            {
                HotBar[i].SetActive(false);
            }
            OnFirstBar = true;
        }
    }

    public void UsePosterPiece(GameObject ObjToPlace)
    {
        int i = ObjToPlace.GetComponent<InvSlot>().CurrentInventorySlot;
        GameObject temp = Instantiate(ObjToPlace.GetComponent<PosterPiece>().thisPosterPiece, HotBar[i].transform.position, Quaternion.identity, canvasObject.transform);
        Debug.Log("Inst");
    }
}
