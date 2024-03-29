using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGame : MonoBehaviour
{
    public GameObject emptySpace;
    private const float DISTANCE_BETWEEN_TILES = 201f;
    private Vector2 tempAnchoredPosition;
    public GameObject gameManager;

    public GameObject[] Buttons;
    public GameObject[] WinPos;
    public GameObject slideGame;
    public GameObject[] posterPieces;

    private Vector2 OriginalSpot1;
    private Vector2 OriginalSpot2;
    private Vector2 OriginalSpot3;
    private Vector2 OriginalSpot4;
    private Vector2 OriginalSpot5;
    private Vector2 OriginalSpot6;
    private Vector2 OriginalSpot7;
    private Vector2 OriginalSpot8;
    private Vector2 OriginalSpotEmpty;

    private AudioSource slideSource;
    public AudioClip slideClip;
    public AudioClip win;

    private Coroutine coroutine;
    private bool puzzleCompleted;

    public GameObject winPar;
    public GameObject posOfParticles;
    private GameObject tempWinEffect;
    public GameObject posterInteractObj;

    public GameObject ninthPiece;

    private void Start()
    {
        OriginalSpot1 = Buttons[0].GetComponent<RectTransform>().anchoredPosition;
        OriginalSpot2 = Buttons[1].GetComponent<RectTransform>().anchoredPosition;
        OriginalSpot3 = Buttons[2].GetComponent<RectTransform>().anchoredPosition;
        OriginalSpot4 = Buttons[3].GetComponent<RectTransform>().anchoredPosition;
        OriginalSpot5 = Buttons[4].GetComponent<RectTransform>().anchoredPosition;
        OriginalSpot6 = Buttons[5].GetComponent<RectTransform>().anchoredPosition;
        OriginalSpot7 = Buttons[6].GetComponent<RectTransform>().anchoredPosition;
        OriginalSpot8 = Buttons[7].GetComponent<RectTransform>().anchoredPosition;
        OriginalSpotEmpty = Buttons[8].GetComponent<RectTransform>().anchoredPosition;

        slideSource = GetComponent<AudioSource>();
        puzzleCompleted = false;
    }

    public void slide(RectTransform clickedTile)
    {
        if (!puzzleCompleted)
        {
            if (Mathf.Sqrt(Mathf.Pow(clickedTile.anchoredPosition.x - emptySpace.GetComponent<RectTransform>().anchoredPosition.x, 2) + Mathf.Pow(clickedTile.anchoredPosition.y - emptySpace.GetComponent<RectTransform>().anchoredPosition.y, 2)) < DISTANCE_BETWEEN_TILES)
            {
                slideSource.pitch = Random.Range(0.8f, 1f);
                slideSource.PlayOneShot(slideClip, 1f);
                //Debug.Log("it worked");
                //Debug.Log(Mathf.Sqrt(Mathf.Pow(clickedTile.anchoredPosition.x - emptySpace.GetComponent<RectTransform>().anchoredPosition.x, 2) + Mathf.Pow(clickedTile.anchoredPosition.y - emptySpace.GetComponent<RectTransform>().anchoredPosition.y, 2)));
                tempAnchoredPosition = emptySpace.GetComponent<RectTransform>().anchoredPosition;
                emptySpace.GetComponent<RectTransform>().anchoredPosition = clickedTile.anchoredPosition;
                clickedTile.anchoredPosition = tempAnchoredPosition;
                CheckWin();


            }
            else
            {
                //Debug.Log("OOF");
                //Debug.Log(Mathf.Sqrt(Mathf.Pow(clickedTile.anchoredPosition.x - emptySpace.GetComponent<RectTransform>().anchoredPosition.x, 2) + Mathf.Pow(clickedTile.anchoredPosition.y - emptySpace.GetComponent<RectTransform>().anchoredPosition.y, 2)));
            }
        }
    }

    private void CheckWin()
    {
        int i = 0;

        foreach (GameObject tempButton in Buttons)
        {
            if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow(tempButton.GetComponent<RectTransform>().anchoredPosition.x - WinPos[i].GetComponent<RectTransform>().anchoredPosition.x, 2) + Mathf.Pow(tempButton.GetComponent<RectTransform>().anchoredPosition.y - WinPos[i].GetComponent<RectTransform>().anchoredPosition.y, 2))) < 5)
            {
                //Debug.Log(Mathf.Abs(tempButton.GetComponent<RectTransform>().anchoredPosition.magnitude - WinPos[i].GetComponent<RectTransform>().anchoredPosition.magnitude));
                i++;
                if (i == 9)
                {
                    puzzleCompleted = true;
                    gameManager.GetComponent<WinSound>().PlayWinSound();
                    tempWinEffect = Instantiate(winPar, posOfParticles.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
                    posterInteractObj.SetActive(true);
                    ninthPiece.SetActive(true);
                    coroutine = StartCoroutine(WaitTime());
                }
               

            }
            else
            {
                i = 0;
                //Debug.Log(i + "is false");
                break;
            }
        }
    }

    public void CHEAT()
    {
        puzzleCompleted = true;
        gameManager.GetComponent<WinSound>().PlayWinSound();
        tempWinEffect = Instantiate(winPar, posOfParticles.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        posterInteractObj.SetActive(true);
        ninthPiece.SetActive(true);
        coroutine = StartCoroutine(WaitTime());
    }

    public void ResetSlideGame()
    {
        Buttons[0].GetComponent<RectTransform>().anchoredPosition = OriginalSpot1;
        Buttons[1].GetComponent<RectTransform>().anchoredPosition = OriginalSpot2;
        Buttons[2].GetComponent<RectTransform>().anchoredPosition = OriginalSpot3;
        Buttons[3].GetComponent<RectTransform>().anchoredPosition = OriginalSpot4;
        Buttons[4].GetComponent<RectTransform>().anchoredPosition = OriginalSpot5;
        Buttons[5].GetComponent<RectTransform>().anchoredPosition = OriginalSpot6;
        Buttons[6].GetComponent<RectTransform>().anchoredPosition = OriginalSpot7;
        Buttons[7].GetComponent<RectTransform>().anchoredPosition = OriginalSpot8;
        Buttons[8].GetComponent<RectTransform>().anchoredPosition = OriginalSpotEmpty;
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.5f);
        slideGame.SetActive(false);
        ninthPiece.SetActive(false);
        foreach (GameObject k in posterPieces)
        {
            k.SetActive(true);
        }
        Destroy(tempWinEffect);
    }
}