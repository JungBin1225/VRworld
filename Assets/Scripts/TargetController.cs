using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject effect;

    public float posZ;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject bulletEffect = Instantiate(effect) as GameObject;
        bulletEffect.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, posZ);
        bulletEffect.GetComponent<ParticleSystem>().Play();
    }
}
