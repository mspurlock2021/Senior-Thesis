using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLight : MonoBehaviour
{
    public GameObject LampObject;
    // Start is called before the first frame update

    private void OnEnable()
    {
        LampObject.GetComponent<Lamp>().turnLampOff();
    }

    private void OnDisable()
    {
        LampObject.GetComponent<Lamp>().turnLampOn();
    }
}
