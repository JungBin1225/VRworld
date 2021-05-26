using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour
{
    public GameObject player;
    private Vector3 randomPos;
    private Vector3 dir;

    public bool attention;
    public float time = 2.5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        randomPos = Random.insideUnitSphere * 20;
    }

    void Update()
    {
        transform.position = randomPos;
        if(transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, transform.position.z);
        }

        dir = player.transform.position - this.gameObject.transform.position;

        if (dir.magnitude < 20 && attention)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 2.5f;
        }

        if(time < 0)
        {
            time = 2.5f;
            randomPos = player.transform.position + Random.insideUnitSphere * 20;
        }
    }

    public void OnLookItemBox(bool isLookAt)
    {
        Debug.Log(isLookAt);
        attention = isLookAt;
    }
}
