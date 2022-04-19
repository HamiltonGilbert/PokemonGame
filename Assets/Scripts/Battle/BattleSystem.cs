using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{

    [SerializeField] List<PokemonBase> pokeListPond;
    [SerializeField] List<PokemonBase> pokeListGrass;

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

        PokemonBase[] pokeList = Resources.LoadAll<PokemonBase>("Pokemon");
        foreach (PokemonBase p in pokeList)
        {
            if (p.Location == PokemonBase.Area.GRASS)
                pokeListGrass.Add(p);
            else
                pokeListPond.Add(p);
        }
    }

    public void SetupBattle(PokemonBase pokemon)
    {
        battleCanvas.alpha = 1;
        InBattle = true;
        cameraMain.SetActive(false);
        cameraBattle.SetActive(true);
        enemyUnit._base = pokemon;
        enemyUnit.Setup();
        enemyHud.SetData(enemyUnit.Pokemon);
    }
    public void PokemonChooser(PokemonBase.Area area)
    {
        if (area.Equals(PokemonBase.Area.GRASS))
        {
            int i = Random.Range(0, pokeListGrass.Count);
            int j = Random.Range(0, pokeListGrass[i].Rarity);
            if (j == 0)
                SetupBattle(pokeListGrass[i]);
        }
        else
        {
            int i = Random.Range(0, pokeListPond.Count);
            int j = Random.Range(0, pokeListPond[i].Rarity);
            if (j == 0)
                SetupBattle(pokeListPond[i]);
        }
    }

    public void EndBattle()
    {
        battleCanvas.alpha = 0;
        InBattle = false;
        cameraMain.SetActive(true);
        cameraBattle.SetActive(false);
    }
}