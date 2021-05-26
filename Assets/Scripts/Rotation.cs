using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float time;
    public GameObject stage;

    public bool start = false;
    private bool rotation = true;
    private bool up = true;

    void Start()
    {
        time = Random.Range(5.0f, 10.0f);
        stage = GameObject.Find("StageManager");
    }

    
    void Update()
    {
        if(start)
        {
            stage.GetComponent<MusicRoom>().state = "Playing";
            if (rotation)
            {
                if (time > 0)
                {
                    time -= Time.deltaTime;
                    transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 0.2f);
                }
                else
                {
                    time = Random.Range(3.0f, 6.0f);
                    rotation = false;
                }
            }
            else
            {
                if (time > 0)
                {
                    time -= Time.deltaTime;
                    if (up)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
                        if (transform.position.y > 5)
                        {
                            up = false;
                        }
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
                        if (transform.position.y < 1)
                        {
                            up = true;
                        }
                    }
                }
                else
                {
                    time = Random.Range(5.0f, 10.0f);
                    stage.GetComponent<MusicRoom>().state = "Select";
                    rotation = true;
                    start = false;
                }
            }
        }
    }

    public void startQuiz()
    {
        if(stage.GetComponent<MusicRoom>().state.Equals("Start"))
        {
            start = true;
        }
    }
}
