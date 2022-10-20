using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCorrOutline : MonoBehaviour
{
    public string kindOfObject;
    public string objToFind;
    public GameObject posterOutlinePiece;
    public GameObject correctPosterPiece;
    private void Start()
    {
        if (kindOfObject == "poster")
        {
            posterOutlinePiece = GameObject.Find(objToFind);
            correctPosterPiece = posterOutlinePiece.GetComponent<PosterPiece>().thisPosterPiece;
        }
        if (kindOfObject == "key")
            posterOutlinePiece = GameObject.Find(objToFind);
    }
}
