using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutObject : MonoBehaviour
{
    public bool isCut = false;
    public Vector3 enterPos;
    public Vector3 exitPos;
    public Material capMaterial;

    public Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - (transform.position.x * Time.deltaTime * 0.8f), transform.position.y - (transform.position.y * Time.deltaTime * 0.8f), transform.position.z - (transform.position.z * Time.deltaTime * 0.8f));
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        else
        {
            enterPos = collision.contacts[0].point;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        exitPos = collision.transform.position;

        GameObject[] gameObjects = MeshCut.Cut(this.gameObject, (enterPos + exitPos) / 2, Vector3.Cross(-transform.position, enterPos - exitPos), capMaterial);
        gameObjects[0].GetComponent<Rigidbody>().AddForce(-Vector3.Cross(-transform.position, enterPos - exitPos).normalized, ForceMode.Impulse);
        gameObjects[1].GetComponent<Rigidbody>().AddForce(Vector3.Cross(-transform.position, enterPos - exitPos).normalized, ForceMode.Impulse);

        Destroy(this.gameObject);
       
    }
}
