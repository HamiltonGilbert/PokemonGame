using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSystem : MonoBehaviour
{
    [SerializeField] CanvasGroup mainCanvas;
    [SerializeField] GameObject cameraMain;

    public void StartMain()
    {
        mainCanvas.alpha = 1;
        cameraMain.SetActive(true);
    }

    public void LeaveMain()
    {
        cameraMain.SetActive(false);
        mainCanvas.alpha = 0;
    }
}

