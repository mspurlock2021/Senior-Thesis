using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScroll : MonoBehaviour
{
    public RectTransform cam;
    public int margin;
    public float scrollSpeed;
    public int maximum;
    public int minimum;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Main Menu");

        if ((Input.mousePosition.x > Screen.width - margin && cam.transform.position.x < maximum) || (Input.GetKey(KeyCode.D) && cam.transform.position.x < maximum))
        {
            cam.anchoredPosition = new Vector2(cam.anchoredPosition.x - scrollSpeed * Time.deltaTime, cam.anchoredPosition.y);
            //cam.transform.position = new Vector3(cam.transform.position.x + scrollSpeed * Time.deltaTime, cam.transform.position.y, cam.transform.position.z);
        }
        else if (cam.transform.position.x > maximum)
            cam.transform.position = new Vector3(maximum, cam.transform.position.y, cam.transform.position.z);

        if ((Input.mousePosition.x <  margin && cam.transform.position.x > minimum) || (Input.GetKey(KeyCode.A) && cam.transform.position.x > minimum))
        {
            cam.transform.position = new Vector3(cam.transform.position.x + scrollSpeed * Time.deltaTime, cam.transform.position.y, cam.transform.position.z);
        }
        else if (cam.transform.position.x < minimum)
            cam.transform.position = new Vector3(minimum, cam.transform.position.y, cam.transform.position.z);

        //Debug.Log(cam.transform.position.y);

    }
}
