using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBar : MonoBehaviour
{
    [SerializeField] Transform greenBar;
    [SerializeField] Transform line;

    private float halfBarLength;

    private float lineSpeed;

    public bool Catching { get; set; }

    public void SetBar(float catchDifficulty, float lineSpeed)
    {
        Catching = true;
        halfBarLength = 1 / catchDifficulty * 70/2;
        greenBar.localScale = new Vector3(1/catchDifficulty, 1f);
        line.localPosition = new Vector3(-103,0,0);
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
        line.position += Vector3.right * lineSpeed * deltaTime;
        if (line.localPosition.x >= 103 || line.localPosition.x <= -103)
        {
            lineSpeed *= -1;
        }
    }

    public bool CheckIfCaught()
    {
        if (line.localPosition.x > -1 * halfBarLength && line.localPosition.x < halfBarLength)
            return true;
        else
            return false;
    }
}
