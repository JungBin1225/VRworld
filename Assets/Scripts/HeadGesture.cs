using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGesture : MonoBehaviour
{
    public float speedRate = 200;
    public float previousAngle;
    public int direction = 0;
    public GameObject player;
    public GameObject panel;
    public float coolDown = 2.5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        panel = GameObject.Find("Canvas3");
        previousAngle = CameraAngle();
    }

    void Update()
    {
        if(coolDown > 0)
        {
            coolDown -= Time.deltaTime;

            previousAngle = CameraAngle();
        }
        else
        {
            if (DetectMoving())
            {
                player.transform.position = new Vector3(player.transform.position.x + (2 * direction), player.transform.position.y, player.transform.position.z);
                panel.transform.position = new Vector3(panel.transform.position.x + (2 * direction), panel.transform.position.y, panel.transform.position.z);

                coolDown = 2.5f;
            }
        }
        
    }

    private float CameraAngle()
    {
        return Vector3.Angle(Vector3.right, Camera.main.transform.rotation * Vector3.forward);
    }

    private bool DetectMoving()
    {
        float angle = CameraAngle();
        float deltaAngle = previousAngle - angle;

        float rate = deltaAngle / Time.deltaTime;
        previousAngle = angle;

        if(deltaAngle > 0)
        {
            direction = -1;
        }
        else if(deltaAngle < 0)
        {
            direction = 1;
        }
        else
        {
            direction = 0;
        }

        return (Mathf.Abs(rate) >= speedRate && Mathf.Abs(deltaAngle) > 5);
    }
}
