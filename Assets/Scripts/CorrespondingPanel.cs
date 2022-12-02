using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrespondingPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CorrectPanel;
    public string panelName;

    private void Start()
    {
        if (panelName == "Locket")
        {
            CorrectPanel = GameObject.Find("Game Manager").GetComponent<GetGameObject>().locketPanel;
        }
        if (panelName == "Hint")
        {
            CorrectPanel = GameObject.Find("Game Manager").GetComponent<GetGameObject>().pinHintPanel;
        }
        if (panelName == "Book")
        {
            CorrectPanel = GameObject.Find("Game Manager").GetComponent<GetGameObject>().bookPanel;
        }
    }
}
