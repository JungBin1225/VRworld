using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicRoom : MonoBehaviour
{
    public string state = "Start";

    public Text text;
    void Start()
    {
        text = GameObject.Find("Message").GetComponent<Text>();
    }

    void Update()
    {
        if(state.Equals("Start"))
        {
            text.text = "Press Start!";
        }
        else if(state.Equals("Playing"))
        {
            text.text = "Location Changing...";
        }
        else if(state.Equals("Select"))
        {
            text.text = "Find Sound!";
        }
    }
}
