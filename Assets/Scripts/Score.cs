using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Goal goal;
    public Text text;

    void Start()
    {
        goal = GameObject.Find("ring").GetComponent<Goal>();
        text = GetComponent<Text>();
    }


    void Update()
    {
        text.text = "Score: " + goal.score.ToString("F0");
    }
}
