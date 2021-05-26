using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongi;
    public Shootcontroller shootcontroller;

    public float time;
    void Start()
    {
        time = 3;
        shootcontroller = GameObject.Find("Player").GetComponent<Shootcontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        time -= Time.deltaTime;

        if(time < 0)
        {
            GameObject bam = Instantiate(bamsongi) as GameObject;
            bam.transform.position = camera.position + shootcontroller.dir;

            time = 3;
        }
        
    }
}
