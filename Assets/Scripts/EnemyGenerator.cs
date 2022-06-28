using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public List<GameObject> enemyPrefeb;
    public List<int> quadrant;

    private GunStageManager stageManager;
    private GameObject player;
    private float spawnTime;
    private int num;
    private int summonNum;
    void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<GunStageManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        spawnTime = 2.0f;
        summonNum = 0;

        initList();
    }

    // Update is called once per frame
    void Update()
    {
        if(stageManager.start)
        {
            spawnTime -= Time.deltaTime;

            if (spawnTime < 0)
            {
                num = Random.Range(0, enemyPrefeb.Count);

                GameObject enemy = Instantiate(enemyPrefeb[num]) as GameObject;
                
                switch(randomQuadrant())
                {
                    case 1:
                        enemy.transform.position = randomPos(player.transform.position.x, player.transform.position.x + 15, player.transform.position.z, player.transform.position.z + 15);
                        break;

                    case 2:
                        enemy.transform.position = randomPos(player.transform.position.x - 15, player.transform.position.x, player.transform.position.z, player.transform.position.z + 15);
                        break;

                    case 3:
                        enemy.transform.position = randomPos(player.transform.position.x - 15, player.transform.position.x, player.transform.position.z - 15, player.transform.position.z);
                        break;

                    case 4:
                        enemy.transform.position = randomPos(player.transform.position.x, player.transform.position.x + 15, player.transform.position.z - 15, player.transform.position.z);
                        break;
                }
                enemy.GetComponent<EnemyController>().type = enemyPrefeb[num].name;
                summonNum++;

                spawnTime = 2.0f - (summonNum * 0.01f);
            }
        }
        else
        {
            spawnTime = 2.0f;
        }
    }

    private Vector3 randomPos(float minX, float maxX, float minZ, float maxZ)
    {
        Vector3 pos;
        float posX;
        float posZ;

        posX = Random.Range(minX, maxX);
        posZ = Random.Range(minZ, maxZ);

        if ((posX - player.transform.position.x) < 4 && (posX - player.transform.position.x) > -4 && (posZ - player.transform.position.z) < 4 && (posZ - player.transform.position.z) > -4)
        {
            if(posX < 0)
            {
                posX = Random.Range(minX, player.transform.position.x - 4);
            }
            else
            {
                posX = Random.Range(player.transform.position.x + 4, maxX);
            }

            if (posZ < 0)
            {
                posZ = Random.Range(minZ, player.transform.position.z - 4);
            }
            else
            {
                posZ = Random.Range(player.transform.position.z + 4, maxZ);
            }
        }

        pos = new Vector3(posX, 0, posZ);

        return pos;
    }

    private int randomQuadrant()
    {
        int result;
        int num;

        if(quadrant.Count == 0)
        {
            initList();
        }

        num = Random.Range(0, quadrant.Count);
        result = quadrant[num];
        quadrant.Remove(result);

        Debug.Log(result);
        return result;
    }

    private void initList()
    {
        quadrant.Add(1);
        quadrant.Add(2);
        quadrant.Add(3);
        quadrant.Add(4);
    }
}
