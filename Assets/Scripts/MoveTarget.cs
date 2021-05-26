using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public GameObject target;
    public GameObject player;

    public Vector3 firstPos;
    public Vector3 secondPos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        firstPos = new Vector3(-8, 13, -13);
        secondPos = new Vector3(-30, 13, -9);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Enemy"))
        {
            target.GetComponent<AiMove>().firstTarget = !target.GetComponent<AiMove>().firstTarget;
        }
    }
}
