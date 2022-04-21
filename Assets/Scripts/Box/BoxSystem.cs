using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxSystem : MonoBehaviour
{
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] MainSystem mainSystem;

    private readonly List<GameObject> boxes = new List<GameObject>();
    [SerializeField] Transform BoxesParent;

    [SerializeField] CanvasGroup boxCanvas;
    [SerializeField] GameObject cameraBox;
    [SerializeField] Button boxButton;

    public bool InBox { get; set; }

    private void Start()
    {
        InBox = false;
        boxCanvas.alpha = 0;
        cameraBox.SetActive(false);

        for (int i=0; i < BoxesParent.childCount; i++)
        {
            boxes.Add(BoxesParent.GetChild(i).gameObject);
        }

        boxButton.onClick.AddListener(SetupBox);
    }

    public void PokemonCaught(PokemonBase pokemon)
    {
        foreach (GameObject box in boxes) {
            if (box.name.Equals(pokemon.Name))
            {
                box.GetComponent<Image>().color = new Color(255f, 255f, 255f, 1f);
            }
        }
    }

    public void SetupBox()
    {
        boxCanvas.alpha = 1;
        InBox = true;
        cameraBox.SetActive(true);
        mainSystem.LeaveMain();
    }
    public void LeaveBox()
    {
        InBox = false;
        boxCanvas.alpha = 0;
        cameraBox.SetActive(false);
        mainSystem.StartMain();
    }
}

