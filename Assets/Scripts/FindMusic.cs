using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMusic : MonoBehaviour
{
    public GameObject stage;

    void Start()
    {
        stage = GameObject.Find("StageManager");
    }

    void Update()
    {
        if(stage.GetComponent<MusicRoom>().state.Equals("Start"))
        {
            this.gameObject.SetActive(false);
        }
    }

    public void findSuccess()
    {
        stage.GetComponent<MusicRoom>().state = "Start";
    }
}
