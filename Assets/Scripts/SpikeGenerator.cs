using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public Vector3 pos1;

    public Quaternion rot1;

    public GameObject spikePrefeb;
    public float time = 3;

    void Start()
    {
        
    }

    void Update()
    {
        if(GameManager.gameManager.gameOver)
        {
            time = 3;
        }
        else
        {
            time -= Time.deltaTime;

            if (time < 0)
            {
                pos1 = GameObject.Find("spikePos1").transform.position;
                pos1.y = 1.8f;

                rot1 = GameObject.Find("spikePos1").transform.rotation;

                GameObject spike1 = Instantiate(spikePrefeb) as GameObject;
                spike1.transform.position = pos1;
                spike1.transform.rotation = rot1;

                time = Random.Range(2.5f, 5);
            }
        }
    }
}
