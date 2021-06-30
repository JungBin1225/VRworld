using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GunStageManager : MonoBehaviour
{
    public bool start = false;
    private GameObject gun;
    private float time;
    private Text timeText;

    void Start()
    {
        gun = GameObject.Find("Gun");
        time = 60;
        timeText = GameObject.Find("Time").GetComponent<Text>();
    }

    void Update()
    {
        if(!GameManager.gameManager.gameOver)
        {
            if (!start)
            {
                gun.SetActive(false);
            }
            else
            {
                gun.SetActive(true);
                time -= Time.deltaTime;
                timeText.text = "0:" + time.ToString("F2");
                if (time < 0)
                {
                    time = 0;
                    gameOver();
                }
            }
        }
    }

    public void gameOver()
    {
        GameManager.gameManager.gameOver = true;
        GameManager.gameManager.score = 0;
        GvrCardboardHelpers.Recenter();
        GameObject cam = GameObject.Find("RawImage");
        cam.GetComponent<MoblieCam>().activeCameraTexture.Stop();
        SceneManager.LoadScene("GunGameOver");
    }

    public void restart()
    {
        GameManager.gameManager.gameOver = false;
        GvrCardboardHelpers.Recenter();
        GameObject cam = GameObject.Find("RawImage");
        cam.GetComponent<MoblieCam>().activeCameraTexture.Stop();
        SceneManager.LoadScene("Gun");
    }

    public void mainmenu()
    {
        GameManager.gameManager.gameOver = false;
        GameManager.gameManager.maxScore = 0;
        GvrCardboardHelpers.Recenter();
        GameObject cam = GameObject.Find("RawImage");
        cam.GetComponent<MoblieCam>().activeCameraTexture.Stop();
        SceneManager.LoadScene("MainMenu");
    }
}
