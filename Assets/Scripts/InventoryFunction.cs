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
    private int inventorySlotInUse;
    private bool usingInventroy;
    private GameObject currentlyHeld;
    private const float DISTANCE_TO_PLACE_POSTER_PIECE = 50f;
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
        usingInventroy = false;
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
        if (!usingInventroy)
        {
            inventorySlotInUse = ObjToPlace.GetComponent<InvSlot>().CurrentInventorySlot;
            currentlyHeld = Instantiate(ObjToPlace.GetComponent<PosterPiece>().thisPosterPiece, HotBar[inventorySlotInUse].transform.position, Quaternion.identity, canvasObject.transform);
            HotBar[inventorySlotInUse].transform.GetChild(0).gameObject.SetActive(false);
            usingInventroy = true;
            //Debug.Log("Inst");
        }
    }

    public void PlacePiece(GameObject thisPiece)
    {
        if (posterPanel.activeSelf)
        {
            RectTransform posterOutline = currentlyHeld.GetComponent<FindCorrOutline>().posterOutlinePiece.GetComponent<RectTransform>();
            if (Mathf.Sqrt(Mathf.Pow(posterOutline.anchoredPosition.x - currentlyHeld.GetComponent<RectTransform>().anchoredPosition.x, 2) + Mathf.Pow(posterOutline.anchoredPosition.y - currentlyHeld.GetComponent<RectTransform>().anchoredPosition.y, 2)) < DISTANCE_TO_PLACE_POSTER_PIECE)
            {
                currentlyHeld.GetComponent<FindCorrOutline>().correctPosterPiece.SetActive(true);
                Destroy(thisPiece);
                Destroy(HotBar[inventorySlotInUse].transform.GetChild(0).gameObject);
                usingInventroy = false;
            }
            else
            {
                Destroy(thisPiece);
                HotBar[inventorySlotInUse].transform.GetChild(0).gameObject.SetActive(true);
                usingInventroy = false;
            }
        }
        else
        {
            Destroy(thisPiece);
            HotBar[inventorySlotInUse].transform.GetChild(0).gameObject.SetActive(true);
            usingInventroy = false;
        }
    }
}
