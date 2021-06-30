using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private float time = 5;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Camera.main.transform.rotation * Vector3.forward * 500);
    }

    void Update()
    {
        time -= Time.deltaTime;

        if(time < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
