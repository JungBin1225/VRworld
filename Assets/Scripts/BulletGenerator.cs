using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    //발사 효과음
    public GameObject bulletPrefeb;
    public GameObject gun;

    private GameObject muzzle;
    private GunStageManager stageManager;
    private float generateSpeed;
    void Start()
    {
        muzzle = GameObject.Find("muzzle");
        stageManager = GameObject.Find("StageManager").GetComponent<GunStageManager>();
        generateSpeed = 0.3f;
    }

    
    void Update()
    {
        if(stageManager.start)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(bulletPrefeb) as GameObject;
                bullet.transform.position = muzzle.transform.position;
                bullet.transform.rotation = muzzle.transform.rotation;
            }

            if (Input.GetMouseButton(0))
            {
                generateSpeed -= Time.deltaTime;

                if(generateSpeed < 0)
                {
                    GameObject bullet = Instantiate(bulletPrefeb) as GameObject;
                    bullet.transform.position = muzzle.transform.position;
                    bullet.transform.rotation = muzzle.transform.rotation;

                    generateSpeed = 0.3f;
                }
            }

            if(Input.GetMouseButtonUp(0))
            {
                generateSpeed = 0.3f;
            }
        }
    }
}
