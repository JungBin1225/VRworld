using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Capture capture;

    Text text;

    void Start()
    {
        capture = GameObject.Find("PictureCanvas").GetComponent<Capture>();
        text = GetComponent<Text>();
    }

    void Update()
    {
        if(!capture.timer)
        {
            text.text = "";
        }
        else
        {
            text.text = capture.time.ToString("F0");
        }
    }
}
