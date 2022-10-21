using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public Texture2D normalCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 NormHotspot;
    private AudioSource pickupSource;
    public AudioClip pickupClip;
    public AudioClip placePosterPiece;
    private int piecesPlaced;
    private void Start()
    {
        piecesPlaced = 0;
        pickupSource = GetComponent<AudioSource>();
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
            if (filledSlots[i] == false)
            {
                GameObject temp = Instantiate(ObjToAddToInv.GetComponent<PosterPiece>().thisPosterPiece, HotBar[i].transform);
                temp.GetComponent<InvSlot>().CurrentInventorySlot = i;
                Destroy(ObjToAddToInv);
                filledSlots[i] = true;
                Cursor.SetCursor(normalCursor, NormHotspot, cursorMode);
                pickupSource.pitch = Random.Range(0.8f, 1f);
                pickupSource.PlayOneShot(pickupClip, 0.2f);
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
                filledSlots[inventorySlotInUse] = false;
                Destroy(HotBar[inventorySlotInUse].transform.GetChild(0).gameObject);
                usingInventroy = false;
                pickupSource.pitch = Random.Range(0.8f, 1f);
                pickupSource.PlayOneShot(placePosterPiece, 0.2f);
                piecesPlaced++;
                if (piecesPlaced == 12)
                {
                    GetComponent<WinSound>().PlayWinSound();
                }
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

    public void PlaceObject(GameObject thisPiece)
    {
        if (!this.GetComponent<PanelActive>().panelOn)
        {
            bool whereToPlace = currentlyHeld.GetComponent<FindCorrOutline>().posterOutlinePiece.GetComponent<Mousedetection>().curentlyHovering;
            if (whereToPlace)
            {
                //currentlyHeld.GetComponent<FindCorrOutline>().correctPosterPiece.SetActive(true);
                SceneManager.LoadScene("Level 2");
                Destroy(thisPiece);
                filledSlots[inventorySlotInUse] = false;
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
