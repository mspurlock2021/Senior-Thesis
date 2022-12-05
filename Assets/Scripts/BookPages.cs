using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPages : MonoBehaviour
{
    public GameObject[] bookPages;
    private int currentPage;


    private void Start()
    {
        currentPage = 0;
    }

    public void NextPressed()
    {
        bookPages[currentPage].SetActive(false);
        currentPage++;
        bookPages[currentPage].SetActive(true);
    }

    public void PreviousPressed()
    {
        bookPages[currentPage].SetActive(false);
        currentPage--;
        bookPages[currentPage].SetActive(true);
    }

}
