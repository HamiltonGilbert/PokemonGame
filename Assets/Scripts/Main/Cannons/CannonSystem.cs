using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSystem : MonoBehaviour
{
    [SerializeField] GameObject[] cannons;
    [SerializeField] CannonBall cannonBall;
    [SerializeField] Transform offScreen;
    // Start is called before the first frame update
    void Start()
    {
        //cannonBall.position = offScreen.position;
    }

    public void Fire()
    {
        cannonBall.Fire(gameObject.transform.position, Vector3.down);
    }
}
