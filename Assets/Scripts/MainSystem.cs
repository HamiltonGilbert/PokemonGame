using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSystem : MonoBehaviour
{
    [SerializeField] BoxSystem boxSystem;
    [SerializeField] BattleSystem battleSystem;

    [SerializeField] Button boxButton;

    [SerializeField] CanvasGroup mainCanvas;
    [SerializeField] GameObject cameraMain;

    public void StartMain()
    {
        cameraMain.SetActive(true);
        mainCanvas.alpha = 1;
    }

    public void LeaveMain()
    {
        cameraMain.SetActive(false);
        mainCanvas.alpha = 0;
    }
}

