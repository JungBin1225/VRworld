using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefeb;
    public GameObject humanPrefeb;

    private GunStageManager stageManager;
    private GameObject player;
    private float spawnTime;
    private int num;
    void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<GunStageManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        spawnTime = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(stageManager.start)
        {
            spawnTime -= Time.deltaTime;

            if (spawnTime < 0)
            {
                num = Random.Range(0, 5);

                if (num == 0)
                {
                    GameObject human = Instantiate(humanPrefeb) as GameObject;
                    human.transform.position = randomPos();
                    human.GetComponent<EnemyController>().type = "human";
                }
                else
                {
                    GameObject enemy = Instantiate(enemyPrefeb) as GameObject;
                    enemy.transform.position = randomPos();
                    enemy.GetComponent<EnemyController>().type = "enemy";
                }

                spawnTime = Random.Range(1.5f, 2.5f);
            }
        }
        else
        {
            spawnTime = 2.0f;
        }
    }

    private Vector3 randomPos()
    {
        Vector3 pos;
        float posX;
        float posZ;

        posX = Random.Range(player.transform.position.x - 15, player.transform.position.x + 15);
        posZ = Random.Range(player.transform.position.z - 15, player.transform.position.z + 15);

        if((posX - player.transform.position.x) < 4 && (posX - player.transform.position.x) > -4)
        {
            posX = Random.Range(player.transform.position.x + 4, player.transform.position.x + 15);
        }

        if ((posZ - player.transform.position.z) < 4 && (posZ - player.transform.position.z) > -4)
        {
            posZ = Random.Range(player.transform.position.z + 4, player.transform.position.z + 15);
        }

        pos = new Vector3(posX, 0, posZ);

        return pos;
    }
}
