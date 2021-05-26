using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bamsongicontroller : MonoBehaviour
{
    public Shootcontroller shootcontroller;
    public GameObject player;

    public float time;

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        shootcontroller = GameObject.Find("Player").GetComponent<Shootcontroller>();
        time = 6;
    }

    private void Update()
    {
        Transform camera = Camera.main.transform;
        Vector3 direction = camera.position - transform.position;
        time -= Time.deltaTime;

        if(direction.magnitude <= 1)
        {
            Shoot(shootcontroller.dir * 1000);
        }

        if(time < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
    }
}
