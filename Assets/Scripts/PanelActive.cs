using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActive : MonoBehaviour
{
    public bool panelOn;
    public bool viewPanelOn;
    public bool pausePanelOn;
    // Start is called before the first frame update
    void Start()
    {
        panelOn = false;
        viewPanelOn = false;
        pausePanelOn = false;
    }
}
