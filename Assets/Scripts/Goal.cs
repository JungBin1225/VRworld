using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int location = 1;
    public int score = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if(location == 1)
        {
            transform.position = new Vector3(0, 1.5f, 5);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(location == 2)
        {
            transform.position = new Vector3(-5, 1.3f, 2);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if(location == 3)
        {
            transform.position = new Vector3(0.2f, 2, -4.2f);
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if(location == 4)
        {
            transform.position = new Vector3(5, 1.5f, 1.3f);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        score++;
        location = Random.Range(1, 5);
        Destroy(other.gameObject);
    }
}
