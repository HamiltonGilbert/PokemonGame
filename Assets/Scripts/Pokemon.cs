using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pokemon : MonoBehaviour
{
    [SerializeField] GameObject _pikachu1;
    [SerializeField] GameObject _pikachu2;
    [SerializeField] GameObject _pikachu3;
    [SerializeField] GameObject _bulbasaur1;
    [SerializeField] GameObject _bulbasaur2;
    [SerializeField] GameObject _bulbasaur3;
    [SerializeField] GameObject _charmander1;
    [SerializeField] GameObject _charmander2;
    [SerializeField] GameObject _charmander3;
    [SerializeField] GameObject _squirtle1;
    [SerializeField] GameObject _squirtle2;
    [SerializeField] GameObject _squirtle3;

    [SerializeField] GameObject _expText;

    Hashtable _pokemonList;

    int _exp = 0;

    // Start is called before the first frame update
    void Start()
    {
        ArrayList temp;
        _pokemonList = new Hashtable();
        // add all pokemon to the array
        Transform[] objects = GetComponentsInChildren<Transform>();
        foreach (Transform pokemon in objects)
        {
            if (! pokemon.name.Equals("Pokemon"))
            {
                if (pokemon.name.Contains("_"))
                    _pokemonList[pokemon.name] = new ArrayList();
                else
                {
                    temp = (ArrayList)_pokemonList[pokemon.name.Substring(0, pokemon.name.Length) + "_"];
                    try { temp.Add(pokemon.name); }
                    catch  { Debug.Log("ERROR"); }
                    if (pokemon.name.Contains("3"))
                    {
                        _pokemonList[pokemon.name.Substring(0, pokemon.name.Length)] = temp;

                    }
                }
            }
        }
        foreach (DictionaryEntry p in _pokemonList)
        {
            Debug.Log(p.Key);
            Debug.Log(p.Value);
        }
            
        //transform.Find("pikachu").Find("pikachu1").SetPositionAndRotation(new Vector3(2, 2, -1), Quaternion.identity);
        //transform.Find("pikachu").Find("pikachu1").GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _exp++;
            _expText.GetComponent<Text>().text = "Exp: " + _exp;
        }
    }
}
