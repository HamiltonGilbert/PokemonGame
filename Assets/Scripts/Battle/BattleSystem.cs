using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{

    [SerializeField] BattleUnit enemyUnit;

    [SerializeField] BattleHud enemyHud;

    [SerializeField] CanvasGroup battleCanvas;
    [SerializeField] GameObject cameraMain;
    [SerializeField] GameObject cameraBattle;

    public bool InBattle { get; set; }

    private void Start()
    {
        InBattle = false;
        battleCanvas.alpha = 0;
        cameraBattle.SetActive(false);
    }

    public void SetupBattle()
    {
        battleCanvas.alpha = 1;
        InBattle = true;
        cameraMain.SetActive(false);
        cameraBattle.SetActive(true);
        enemyUnit.Setup();
        enemyHud.SetData(enemyUnit.Pokemon);
    }

    public void EndBattle()
    {
        battleCanvas.alpha = 0;
        InBattle = false;
        cameraMain.SetActive(true);
        cameraBattle.SetActive(false);
    }
}