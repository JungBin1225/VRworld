using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefeb;
    public GameObject effect;
    public GameObject gun;

    void Start()
    {
        effect = GameObject.Find("effect");
    }

    
    void Update()
    {
        if(GameManager.gameManager.inventory.Contains(gun))
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(bulletPrefeb) as GameObject;
                bullet.transform.position = effect.transform.position;
            }
        }
    }
}
