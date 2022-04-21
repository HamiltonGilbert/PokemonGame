using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxSystem : MonoBehaviour
{
    [SerializeField] List<PokemonBase> pokeList;
    [SerializeField] GameObject Boxes;

    [SerializeField] BattleUnit enemyUnit;

    [SerializeField] BattleHud enemyHud;

    [SerializeField] CanvasGroup boxCanvas;
    [SerializeField] GameObject cameraMain;
    [SerializeField] GameObject cameraBox;

    public bool InBox { get; set; }

    private void Start()
    {
        InBox = false;
        boxCanvas.alpha = 0;
        cameraBox.SetActive(false);


    }

    public void SetupBox()
    {
        boxCanvas.alpha = 1;
        InBox = true;
        cameraMain.SetActive(false);
        cameraBox.SetActive(true);
        enemyUnit.Setup();
        enemyHud.SetData(enemyUnit.Pokemon);
    }
    public void PokemonCaught(PokemonBase.Area area)
    {
        
    }

    public void LeaveBox()
    {
        boxCanvas.alpha = 0;
        InBox = false;
        cameraMain.SetActive(true);
        cameraBox.SetActive(false);
    }
}

