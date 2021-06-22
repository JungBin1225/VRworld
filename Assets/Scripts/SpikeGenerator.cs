using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public List<GameObject> spawnPos;

    public List<GameObject> targetPos;

    public List<GameObject> spikePrefeb;

    public float time = 3;

    private int num = 0;
    private int ball = 0;
    private int position1 = 0;
    private int position2 = 0;

    void Start()
    {
        spawnPos.Add(GameObject.Find("spikePos1"));
        spawnPos.Add(GameObject.Find("spikePos2"));
        spawnPos.Add(GameObject.Find("spikePos3"));

        targetPos.Add(GameObject.Find("TargetPos1"));
        targetPos.Add(GameObject.Find("TargetPos2"));
        targetPos.Add(GameObject.Find("TargetPos3"));
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
                num = Random.Range(1, 3);

                if (num == 1)
                {
                    position1 = Random.Range(0, 3);

                    ball = Random.Range(0, 2);
                    GameObject spike1 = Instantiate(spikePrefeb[ball]) as GameObject;
                    spike1.transform.position = new Vector3(spawnPos[position1].transform.position.x, 1.8f, spawnPos[position1].transform.position.z);
                    spike1.transform.rotation = spawnPos[position1].transform.rotation;
                    spike1.GetComponent<SpikeMoving>().target = targetPos[position1].transform.position;
                    spike1.GetComponent<SpikeMoving>().type = spikePrefeb[ball].name;

                    time = Random.Range(2.5f - (0.05f * GameManager.gameManager.avoidNum), 5 - (0.05f * GameManager.gameManager.avoidNum));
                }
                else
                {
                    position1 = Random.Range(0, 3);
                    position2 = Random.Range(0, 3);

                    ball = Random.Range(0, 2);
                    GameObject spike1 = Instantiate(spikePrefeb[ball]) as GameObject;
                    spike1.transform.position = new Vector3(spawnPos[position1].transform.position.x, 1.8f, spawnPos[position1].transform.position.z);
                    spike1.transform.rotation = spawnPos[position1].transform.rotation;
                    spike1.GetComponent<SpikeMoving>().target = targetPos[position1].transform.position;
                    spike1.GetComponent<SpikeMoving>().type = spikePrefeb[ball].name;

                    if (position1 != position2)
                    {
                        ball = Random.Range(0, 2);
                        GameObject spike2 = Instantiate(spikePrefeb[ball]) as GameObject;
                        spike2.transform.position = new Vector3(spawnPos[position2].transform.position.x, 1.8f, spawnPos[position2].transform.position.z);
                        spike2.transform.rotation = spawnPos[position2].transform.rotation;
                        spike2.GetComponent<SpikeMoving>().target = targetPos[position2].transform.position;
                        spike2.GetComponent<SpikeMoving>().type = spikePrefeb[ball].name;
                    }

                    time = Random.Range(2.5f - (0.05f * GameManager.gameManager.avoidNum), 5 - (0.05f * GameManager.gameManager.avoidNum));
                }
            }
        }
    }
}
