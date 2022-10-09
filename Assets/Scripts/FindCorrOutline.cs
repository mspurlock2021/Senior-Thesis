using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCorrOutline : MonoBehaviour
{
    public string objToFind;
    public GameObject posterOutlinePiece;
    public GameObject correctPosterPiece;
    private void Start()
    {
        posterOutlinePiece = GameObject.Find(objToFind);
        correctPosterPiece = posterOutlinePiece.GetComponent<PosterPiece>().thisPosterPiece;
    }
}
