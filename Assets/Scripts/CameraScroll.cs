using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScroll : MonoBehaviour
{
    public RectTransform cam;
    public float margin;
    public float scrollSpeed;
    public int maximum;
    public int minimum;
    private float minLowerBound;
    private float minUpperBound;
    private float maxUpperBound;
    private float maxLowerBound;
    private const float SCREEN_MINIMUM = 0.0f;
    private float currentScrollSpeed;
    private bool canScroll;
    private GameObject musicObject;


    // Start is called before the first frame update
    void Start()
    {
        minLowerBound = SCREEN_MINIMUM;
        minUpperBound = Screen.width * margin;
        maxLowerBound = Screen.width - Screen.width * margin;
        maxUpperBound = Screen.width;
        canScroll = true;
        musicObject = GameObject.Find("Music");
    }

    // Update is called once per frame
    void Update()
    {
        canScroll = !this.GetComponent<PanelActive>().panelOn && !this.GetComponent<PanelActive>().viewPanelOn && !this.GetComponent<PanelActive>().pausePanelOn;

        if (Input.mousePosition.x > maxLowerBound && cam.anchoredPosition.x > maximum && canScroll)
        {
            currentScrollSpeed = scrollSpeed * (Mathf.InverseLerp(maxLowerBound, maxUpperBound, Input.mousePosition.x));
            cam.anchoredPosition = new Vector2(cam.anchoredPosition.x - currentScrollSpeed * Time.deltaTime, cam.anchoredPosition.y);

            if (SceneManager.GetActiveScene().name == "Level 1")
                musicObject.GetComponent<MusicContinuous>().RadioMusic(cam.anchoredPosition.x); 
        }
        else if (cam.anchoredPosition.x < maximum)
        {
            cam.anchoredPosition = new Vector2(maximum, 0);
            if (SceneManager.GetActiveScene().name == "Level 1")
                musicObject.GetComponent<MusicContinuous>().RadioMusic(cam.anchoredPosition.x);
        }

        if (Input.mousePosition.x < minUpperBound && cam.anchoredPosition.x < minimum && canScroll)
        {
            currentScrollSpeed = scrollSpeed * (Mathf.InverseLerp(minUpperBound, minLowerBound, Input.mousePosition.x));
            cam.anchoredPosition = new Vector2(cam.anchoredPosition.x + currentScrollSpeed * Time.deltaTime, cam.anchoredPosition.y);

            if (SceneManager.GetActiveScene().name == "Level 1")
                musicObject.GetComponent<MusicContinuous>().RadioMusic(cam.anchoredPosition.x);
        }
        else if (cam.anchoredPosition.x > minimum)
        {
            cam.anchoredPosition = new Vector2(minimum, 0);
            if (SceneManager.GetActiveScene().name == "Level 1")
                musicObject.GetComponent<MusicContinuous>().RadioMusic(cam.anchoredPosition.x);
        }

    }
}
