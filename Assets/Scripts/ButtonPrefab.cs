using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPrefab : MonoBehaviour
{
    private GameObject gameManager;
    public void CallFunction()
    {
        gameManager = GameObject.Find("Game Manager");
        gameManager.GetComponent<InventoryFunction>().UsePosterPiece(this.gameObject);
    }

    public void CallFunctionPlacePiece()
    {
        gameManager = GameObject.Find("Game Manager");
        gameManager.GetComponent<InventoryFunction>().PlacePiece(this.gameObject);
    }

    public void CallFunctionForObjPlace()
    {
        gameManager = GameObject.Find("Game Manager");
        gameManager.GetComponent<InventoryFunction>().PlaceObject(this.gameObject);
    }

    public void OpenPanel()
    {
        gameManager = GameObject.Find("Game Manager");
        gameManager.GetComponent<InventoryFunction>().ViewHeldItem(this.gameObject);
    }
}
