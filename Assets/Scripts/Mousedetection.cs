using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mousedetection : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    public bool curentlyHovering;


    private void Start()
    {
        curentlyHovering = false;
    }


    //Detect if the Cursor starts to pass over the GameObject
    //public void OnPointerEnter(PointerEventData pointerEventData)
    //{
    //    //Output to console the GameObject's name and the following message
    //    //Debug.Log("Cursor Entering " + name + " GameObject");
    //    //curentlyHovering = true;
    //}

    ////Detect when Cursor leaves the GameObject
    //public void OnPointerExit(PointerEventData pointerEventData)
    //{
    //    //curentlyHovering = false;
    //    //Output the following message with the GameObject's name
    //    //Debug.Log("Cursor Exiting " + name + " GameObject");
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        curentlyHovering = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        curentlyHovering = false;
    }
}