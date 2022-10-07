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
}
