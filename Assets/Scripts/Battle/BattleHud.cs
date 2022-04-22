using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;

    public void SetData(Pokemon pokemon)
    {
        nameText.text = pokemon.Base.Name;
    }
}
