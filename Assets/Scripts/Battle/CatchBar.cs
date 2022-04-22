using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBar : MonoBehaviour
{
    [SerializeField] GameObject greenBar;
    [SerializeField] GameObject line;

    public void SetBar(float barNormalized)
    {
        greenBar.transform.localScale = new Vector3(barNormalized, 1f);
        //line.transform.localScale = 
    }
}
