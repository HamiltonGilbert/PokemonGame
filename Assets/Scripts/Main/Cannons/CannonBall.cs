using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float wiggleInterval;
    [SerializeField] float wiggleDistance;
    [SerializeField] Transform offScreen;

    private float duration;
    private Vector3 direction;
    private bool moving;
    private float time;
    private float moveDirection = 1;

    private void Start()
    {
        duration = 5 / speed;
    }
    private void Update()
    {
        if (moving)
        {
            transform.position += speed * Time.deltaTime * direction;
            time += Time.deltaTime;
            checkIfMoving();
            if (time % wiggleInterval < Time.deltaTime)
            {
                transform.position += wiggleDistance * Vector3.right * moveDirection;
                moveDirection *= -1;
            }
        }   
    }

    public void Fire(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        this.direction = direction;
        moving = true;
        time = 0;
    }

   public void checkIfMoving()
    {
        if (time >= duration)
            moving = false;
    }
}
