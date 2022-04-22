using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBar : MonoBehaviour
{
    [SerializeField] GameObject greenBar;
    [SerializeField] GameObject line;

    private float lineSpeed;

    public bool Catching { get; set; }

    public void SetBar(float catchDifficulty, float lineSpeed)
    {
        Catching = true;
        greenBar.transform.localScale = new Vector3(1/catchDifficulty, 1f);
        line.transform.localPosition = new Vector3(0,0,0);
        this.lineSpeed = lineSpeed;
    }

    void Update()
    {
        if (Catching)
        {
            CatchAnimation(Time.deltaTime);
        }
        
    }

    public void CatchAnimation(float deltaTime)
    {
        line.transform.position += Vector3.right * lineSpeed * deltaTime;
        if (line.transform.localPosition.x >= 103 || line.transform.localPosition.x <= -103)
        {
            lineSpeed *= -1;
        }
    }

    public void CheckIfCaught()
    {

    }
}
