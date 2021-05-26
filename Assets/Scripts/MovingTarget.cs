using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public bool moveRight = true;

    void Update()
    {
        if(moveRight)
        {
            if(transform.position.x < 3.5)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                moveRight = false;
            }
        }
        else
        {
            if (transform.position.x > 1.5)
            {
                transform.position = new Vector3(transform.position.x - Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                moveRight = true;
            }
        }
    }
}
