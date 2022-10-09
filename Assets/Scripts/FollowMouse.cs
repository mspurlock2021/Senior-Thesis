using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowMouse : MonoBehaviour
{
    public GameObject canvasObject;
    public GameObject mainCam;
    // Start is called before the first frame update
    void Start()
    {
        canvasObject = GameObject.Find("Canvas");
        mainCam = GameObject.Find("Main Camera");

        Vector2 pos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasObject.transform as RectTransform, Input.mousePosition, canvasObject.GetComponent<Canvas>().worldCamera, out pos);
    }

    // Update is called once per frame
    void Update()
    {
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasObject.transform as RectTransform, Input.mousePosition, canvasObject.GetComponent<Canvas>().worldCamera, out movePos);

        //this.GetComponent<RectTransform>().anchoredPosition = canvasObject.transform.TransformPoint(movePos);

        CanvasScaler scaler = canvasObject.GetComponent<CanvasScaler>();
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(UnityEngine.Input.mousePosition.x * (scaler.referenceResolution.x / Screen.width) - 1000, UnityEngine.Input.mousePosition.y * (scaler.referenceResolution.y / Screen.height) - 500);
        //Vector2 mousePosition = Camera.main.scree (Input.mousePosition);

        //if (Input.GetMouseButtonDown(0))
        //this.GetComponent<RectTransform>().anchoredPosition = movePos;

        //Debug.Log(movePos);
        //Debug.Log(transform.position);

        //Vector3 pos = Input.mousePosition;
        //pos.z = 

    }
}
