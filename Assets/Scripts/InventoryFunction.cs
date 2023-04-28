using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

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
    public GameObject[] correctPosterPiecesCHEAT = new GameObject[12];
    private Coroutine coroutine;
    
    public GameObject winPar;
    public GameObject posterParPos;
    private GameObject tempWinEffect;

    public AudioMixer MusicMixer;
    public GameObject pauseButton;
    public GameObject lockInteractObj;

    public GameObject swapInvPage;
    public GameObject swapInvPage2;

    public AudioClip buttonClicked;

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
        swapInvPage.SetActive(false);
        swapInvPage2.SetActive(false);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown("2"))
    //    {
    //        SceneManager.LoadScene("Level 2");
    //    }
    //}
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
                pickupSource.PlayOneShot(pickupClip, 1f);
                if (i > 5)
                {
                    swapInvPage.SetActive(true);
                    swapInvPage2.SetActive(true);
                }
                break;
            }
        }
    }

    public void SwapInventory()
    {
        pickupSource.pitch = Random.Range(0.8f, 1f);
        pickupSource.PlayOneShot(buttonClicked, 1f);
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
            pickupSource.pitch = Random.Range(0.8f, 1f);
            pickupSource.PlayOneShot(buttonClicked, 1f);
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
                pickupSource.PlayOneShot(placePosterPiece, 1f);
                piecesPlaced++;
                if(SecondBarEmpty())
                {
                    swapInvPage.SetActive(false);
                    swapInvPage2.SetActive(false);
                    if (!OnFirstBar)
                    {
                        SwapInventory();
                    }
                }
                if (piecesPlaced == 12)
                {
                    GetComponent<WinSound>().PlayWinSound();
                    tempWinEffect = Instantiate(winPar, posterParPos.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
                    lockInteractObj.SetActive(true);
                    coroutine = StartCoroutine(PosterWaitTime());
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
                Destroy(thisPiece);
                filledSlots[inventorySlotInUse] = false;
                Destroy(HotBar[inventorySlotInUse].transform.GetChild(0).gameObject);
                usingInventroy = false;
                this.gameObject.GetComponent<LevelCompleteSound>().PlayWinSound();
                tempWinEffect = Instantiate(winPar, posterParPos.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
                if (SecondBarEmpty())
                {
                    swapInvPage.SetActive(false);
                    swapInvPage2.SetActive(false);
                    if (!OnFirstBar)
                    {
                        SwapInventory();
                    }
                }
                coroutine = StartCoroutine(WaitTime());
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

    public void PosterCHEAT()
    {
        for (int i = 0; i < 12; i++)
        {
            correctPosterPiecesCHEAT[i].SetActive(true);
        }
        GetComponent<WinSound>().PlayWinSound();
        tempWinEffect = Instantiate(winPar, posterParPos.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        lockInteractObj.SetActive(true);
        coroutine = StartCoroutine(PosterWaitTime());
    }

    public void ViewHeldItem (GameObject objToView)
    {
        if (!this.GetComponent<PanelActive>().viewPanelOn && !usingInventroy)
        {
            pickupSource.pitch = Random.Range(0.8f, 1f);
            pickupSource.PlayOneShot(buttonClicked, 1f);
            usingInventroy = true;
            objToView.GetComponent<CorrespondingPanel>().CorrectPanel.SetActive(true);
            this.GetComponent<PanelActive>().viewPanelOn = true;
            pauseButton.transform.SetAsLastSibling();
        }
    }

    public void ExitHeldItemView(GameObject panelToClose)
    {
        {
            pickupSource.pitch = Random.Range(0.8f, 1f);
            pickupSource.PlayOneShot(buttonClicked, 1f);
            usingInventroy = false;
            panelToClose.SetActive(false);
            this.GetComponent<PanelActive>().viewPanelOn = false;
        }
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.5f);
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            MusicMixer.SetFloat("MusicVol", Mathf.Log10(GameObject.Find("Music").GetComponent<MusicContinuous>().MusicVolume) * 20);
            SceneManager.LoadScene("Level 2");
        }
        else
            SceneManager.LoadScene("Win Screen");

        Destroy(tempWinEffect);

    }

    private IEnumerator PosterWaitTime()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(tempWinEffect);
    }

    private bool SecondBarEmpty()
    {
        if (filledSlots[6] == false && filledSlots[7] == false && filledSlots[8] == false && filledSlots[9] == false && filledSlots[10] == false && filledSlots[11] == false)
            return true;
        else
            return false;
    }

}
