using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public List<GameObject> inventory;

    public bool[] distance = new bool[10];
    public bool[] stop = new bool[10];

    public bool gameOver = false;

    public int score = 0;
    public int maxScore = 0;
    public int life = 3;

    public int avoidNum = 0;

    void Awake()
    {
        if (gameManager == null)
            gameManager = this;

        else if (gameManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            distance[i] = false;
        }
        for (int i = 0; i < 10; i++)
        {
            stop[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(score > maxScore)
        {
            maxScore = score;
        }
    }

    public void initArray()
    {
        for (int i = 0; i < 10; i++)
        {
            distance[i] = false;
        }
        for (int i = 0; i < 10; i++)
        {
            stop[i] = false;
        }
    }
}
