using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BoxSystem boxSystem;
    [SerializeField] MainSystem mainSystem;

    private readonly List<PokemonBase> pokeListPond = new List<PokemonBase>();
    private readonly List<PokemonBase> pokeListGrass = new List<PokemonBase>();

    [SerializeField] BattleUnit pokemonUnit;
    [SerializeField] BattleHud battleHud;
    [SerializeField] CatchHud catchHud;
    [SerializeField] float catchHudLineSpeed;
    [SerializeField] CanvasGroup battleCanvas;
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

    
    public PokemonBase PokemonChooser(PokemonBase.Area area)
    {
        if (area.Equals(PokemonBase.Area.GRASS))
        {
            int i = Random.Range(0, pokeListGrass.Count);
            return pokeListGrass[i];
        }
        else
        {
            int i = Random.Range(0, pokeListPond.Count);
            return pokeListPond[i];
        }
    }

    public void PokemonCaught()
    {
        boxSystem.PokemonCaught(pokemonUnit._base);
        EndBattle();
    }

    public void StartBattle(PokemonBase.Area area)
    {
        InBattle = true;
        battleCanvas.alpha = 1;
        cameraBattle.SetActive(true);
        mainSystem.LeaveMain();

        pokemonUnit._base = PokemonChooser(area);
        pokemonUnit.Setup();
        battleHud.SetData(pokemonUnit.Pokemon);
        catchHud.SetData(pokemonUnit.Pokemon, catchHudLineSpeed);
    }
    public void EndBattle()
    {
        InBattle = false;
        battleCanvas.alpha = 0;
        cameraBattle.SetActive(false);
        mainSystem.StartMain();

        catchHud.EndEncounter();
    }
}