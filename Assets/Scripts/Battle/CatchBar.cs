using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBar : MonoBehaviour
{
    [SerializeField] GameObject bar;

    public void SetBar(float barNormalized)
    {
        bar.transform.localScale = new Vector3(barNormalized, 1f);
    }
}
