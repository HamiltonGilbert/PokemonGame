using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSystem : MonoBehaviour
{
    [SerializeField] CanvasGroup mainCanvas;
    [SerializeField] GameObject cameraMain;

    public bool inMain;

    public void Start()
    {
        StartMain();
    }

    public void StartMain()
    {
        inMain = true;
        mainCanvas.alpha = 1;
        cameraMain.SetActive(true);
    }

    public void LeaveMain()
    {
        inMain = false;
        cameraMain.SetActive(false);
        mainCanvas.alpha = 0;
    }
}

