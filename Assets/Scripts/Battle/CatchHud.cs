using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchHud : MonoBehaviour
{
    [SerializeField] CatchBar catchBar;

    public void SetData(Pokemon pokemon, float lineSpeed)
    {
        catchBar.SetBar(pokemon.CatchDifficulty, lineSpeed);
    }

    public void EndEncounter()
    {
        catchBar.Catching = false;
    }
}

