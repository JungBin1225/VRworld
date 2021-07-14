using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGun : MonoBehaviour
{
    public string name;

    private bool isLooking = false;
    private GunStageManager manager;

    void Start()
    {
        manager = GameObject.Find("StageManager").GetComponent<GunStageManager>();
    }

    void Update()
    {
        if(isLooking)
        {
            if(Input.GetMouseButtonDown(0))
            {
                manager.gun_name = name;
                manager.start = true;
                
            }
        }

        if(manager.start)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnLook(bool isLookAt)
    {
        isLooking = isLookAt;
    }

}