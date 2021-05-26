using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AiMove : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    public bool firstTarget = true;

    public bool chase = false;

    public string moveTo;
    public FadeOut fadeout;
    public Vector3 dir;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fadeout = GetComponent<FadeOut>();
    }

    
    void Update()
    {
        dir = player.transform.position - this.gameObject.transform.position;

        if (dir.magnitude < 9)
        {
            target.transform.position = player.transform.position;
            GetComponent<NavMeshAgent>().speed = 0.8f;
        }
        else
        {
            GetComponent<NavMeshAgent>().speed = 0.5f;
            if (firstTarget)
            {
                target.transform.position = target.GetComponent<MoveTarget>().firstPos;
            }
            else
            {
                target.transform.position = target.GetComponent<MoveTarget>().secondPos;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag.Equals("Player"))
        {
            fadeout.moveTo = moveTo;
            fadeout.fade_out = true;
        }
    }
}
