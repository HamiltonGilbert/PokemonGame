using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxSystem : MonoBehaviour
{
    [SerializeField] List<GameObject> boxes;
    [SerializeField] Transform BoxUI;

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

        for (int i=0; i < BoxUI.childCount; i++)
        {
            boxes.Add(BoxUI.GetChild(i).gameObject);
        }
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
    public void PokemonCaught(PokemonBase pokemon)
    {
        foreach (GameObject box in boxes) {
            if (box.name.Equals(pokemon.Name))
            {
                box.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
            }
        }
    }

    public void LeaveBox()
    {
        boxCanvas.alpha = 0;
        InBox = false;
        cameraMain.SetActive(true);
        cameraBox.SetActive(false);
    }
}

