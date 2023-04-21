using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableScript : MonoBehaviour
{
    public GameObject objToActivate;
    private void OnEnable()
    {
        objToActivate.SetActive(true);
    }

}
