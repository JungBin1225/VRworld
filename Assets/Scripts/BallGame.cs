using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGame : MonoBehaviour
{
    public GameObject ball;
    public Goal goal;
    public float startHeight = 5.0f;
    public float interval = 6.0f;
    public bool playing = false;

    private float time = 0f;
    private GameObject activeBall;

    void Start()
    {
        goal = GameObject.Find("ring").GetComponent<Goal>();
    }


    void Update()
    {
        if(playing)
        {
            time += Time.deltaTime;

            if (interval < time)
            {
                time = 0;

                if (goal.location == 1)
                {
                    Vector3 pos = new Vector3(Camera.main.transform.position.x, startHeight, Camera.main.transform.position.z + 0.2f);
                    activeBall = Instantiate(ball, pos, Quaternion.identity) as GameObject;
                }
                else if (goal.location == 2)
                {
                    Vector3 pos = new Vector3(Camera.main.transform.position.x - 0.2f, startHeight, Camera.main.transform.position.z);
                    activeBall = Instantiate(ball, pos, Quaternion.identity) as GameObject;
                }
                else if (goal.location == 3)
                {
                    Vector3 pos = new Vector3(Camera.main.transform.position.x, startHeight, Camera.main.transform.position.z - 0.2f);
                    activeBall = Instantiate(ball, pos, Quaternion.identity) as GameObject;
                }
                else
                {
                    Vector3 pos = new Vector3(Camera.main.transform.position.x + 0.2f, startHeight, Camera.main.transform.position.z);
                    activeBall = Instantiate(ball, pos, Quaternion.identity) as GameObject;
                }
            }
        }
        else
        {
            time = 0;
        }
    }

    public void start(bool isPlaying)
    {
        playing = isPlaying;
        goal.score = 0;
    }
}
