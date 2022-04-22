using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchHud : MonoBehaviour
{
    [SerializeField] CatchBar catchBar;

    public void SetData(PokemonBase pokemon)
    {
        catchBar.SetBar(pokemon.CatchDifficulty);
    }
}

