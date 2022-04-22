using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchHud : MonoBehaviour
{
    [SerializeField] CatchBar catchBar;

    public void SetData(Pokemon pokemon)
    {
        catchBar.SetBar((float)pokemon.HP / pokemon.MaxHP);
    }
}

