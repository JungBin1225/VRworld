using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Camera.main.transform.rotation * Vector3.forward * 1000);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
