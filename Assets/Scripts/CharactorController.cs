using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    Animator damaged_ani;

    void Start()
    {
        damaged_ani = GameObject.Find("damaged_effect").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon")
        {
            if(!other.GetComponent<WeaponDamage>().damaged)
            {
                damaged_ani.SetTrigger("damaged");
                if (GameManager.gameManager.life > 0)
                {
                    if (GameManager.gameManager.life - other.GetComponent<WeaponDamage>().damage < 0)
                    {
                        GameManager.gameManager.life = 0;
                    }
                    else
                    {
                        GameManager.gameManager.life -= other.GetComponent<WeaponDamage>().damage;
                    }
                }
                other.GetComponent<WeaponDamage>().damaged = true;
            }
        }
    }
}
