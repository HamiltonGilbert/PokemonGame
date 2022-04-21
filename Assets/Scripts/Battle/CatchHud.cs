using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchHud : MonoBehaviour
{
    [SerializeField] CatchBar catchBar;

    public void SetData(Pokemon pokemon)
    {
        hpBar.SetHP((float)pokemon.HP / pokemon.MaxHP);
    }
}

