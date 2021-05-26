using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange : MonoBehaviour
{
    public GameObject gun;
    public GameObject playerGun;

    void Start()
    {
        playerGun = GameObject.Find("PlayerGun");
    }

    
    void Update()
    {
        if(GameManager.gameManager.inventory.Contains(gun))
        {
            playerGun.SetActive(true);
        }
        else
        {
            playerGun.SetActive(false);
        }
    }
}
