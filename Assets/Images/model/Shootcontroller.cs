using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootcontroller : MonoBehaviour
{
    public Vector3 dir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;

        dir = camera.rotation * Vector3.forward * 1f;
    }
}
