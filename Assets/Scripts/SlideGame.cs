using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGame : MonoBehaviour
{
    public GameObject emptySpace;
    private const float DISTANCE_BETWEEN_TILES = 201f;
    private Vector2 tempAnchoredPosition;

    //public GameObject button1;
    //public GameObject button2;
    //public GameObject button3;
    //public GameObject button4;
    //public GameObject button5;
    //public GameObject button6;
    //public GameObject button7;
    //public GameObject button8;

    //public GameObject winPos1;
    //public GameObject winPos2;
    //public GameObject winPos3;
    //public GameObject winPos4;
    //public GameObject winPos5;
    //public GameObject winPos6;
    //public GameObject winPos7;
    //public GameObject winPos8;
    //public GameObject winPosEmpty;

    public GameObject[] Buttons;
    public GameObject[] WinPos;
    public GameObject slideGame;
    public GameObject[] posterPieces;


    public void slide(RectTransform clickedTile)
    {
        if (Mathf.Sqrt(Mathf.Pow(clickedTile.anchoredPosition.x - emptySpace.GetComponent<RectTransform>().anchoredPosition.x, 2) + Mathf.Pow(clickedTile.anchoredPosition.y - emptySpace.GetComponent<RectTransform>().anchoredPosition.y, 2)) < DISTANCE_BETWEEN_TILES)
        {
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

    private void CheckWin()
    {
        //if((button1.GetComponent<RectTransform>().anchoredPosition.magnitude == winPos1.GetComponent<RectTransform>().anchoredPosition.magnitude) && (button2.GetComponent<RectTransform>().anchoredPosition.magnitude == winPos2.GetComponent<RectTransform>().anchoredPosition.magnitude) && (button3.GetComponent<RectTransform>().anchoredPosition.magnitude == winPos3.GetComponent<RectTransform>().anchoredPosition.magnitude) && (button4.GetComponent<RectTransform>().anchoredPosition.magnitude == winPos4.GetComponent<RectTransform>().anchoredPosition.magnitude) && (button5.GetComponent<RectTransform>().anchoredPosition.magnitude == winPos5.GetComponent<RectTransform>().anchoredPosition.magnitude) && (button6.GetComponent<RectTransform>().anchoredPosition.magnitude == winPos6.GetComponent<RectTransform>().anchoredPosition.magnitude) && (button7.GetComponent<RectTransform>().anchoredPosition.magnitude == winPos7.GetComponent<RectTransform>().anchoredPosition.magnitude) && (button8.GetComponent<RectTransform>().anchoredPosition.magnitude == winPos8.GetComponent<RectTransform>().anchoredPosition.magnitude) && (emptySpace.GetComponent<RectTransform>().anchoredPosition.magnitude == winPosEmpty.GetComponent<RectTransform>().anchoredPosition.magnitude))
        //{
        //    slideGame.SetActive(false);
        //    Debug.Log("gone!");
        //}
        //else
        //{
        //    //Debug.Log(button1.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(winPos1.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(button2.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(winPos2.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(button3.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(winPos3.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(button4.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(winPos4.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(button5.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(winPos5.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(button6.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(winPos6.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(button7.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(winPos7.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(button8.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(winPos8.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(emptySpace.GetComponent<RectTransform>().anchoredPosition.magnitude);
        //    //Debug.Log(winPosEmpty.GetComponent<RectTransform>().anchoredPosition.magnitude);

        //}

        int i = 0;

        foreach (GameObject tempButton in Buttons)
        {
            if (Mathf.Abs(tempButton.GetComponent<RectTransform>().anchoredPosition.magnitude - WinPos[i].GetComponent<RectTransform>().anchoredPosition.magnitude) < 5)
            {
                //Debug.Log(i);
                i++;
                if (i == 9)
                {
                    slideGame.SetActive(false);
                    foreach (GameObject k in posterPieces)
                    {
                        k.SetActive(true);
                    }
                }
               

            }
            else
            {
                //Debug.Log(i + "is false");
                break;
            }
        }
    }

    public void CHEAT()
    {
        slideGame.SetActive(false);
        foreach (GameObject k in posterPieces)
        {
            k.SetActive(true);
        }
    }
}