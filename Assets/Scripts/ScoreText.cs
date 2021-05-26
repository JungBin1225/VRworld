using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gameManager.gameOver)
        {
            text.text = "Score\n\n" + GameManager.gameManager.score.ToString();
        }
        else
        {
            text.text = "Max Score\n\n" + GameManager.gameManager.maxScore.ToString();
        }
    }
}
