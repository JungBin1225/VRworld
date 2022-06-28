using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GunStageManager : MonoBehaviour
{
    public bool start = false;
    public string gun_name;

    private GameObject gun_m47;
    private GameObject gun_ak47;
    private GameObject gun_bitgun;
    private float time;
    private Text timeText;

    void Start()
    {
        gun_m47 = GameObject.Find("Gun_m47");
        gun_ak47 = GameObject.Find("Gun_ak47");
        gun_bitgun = GameObject.Find("Gun_bitgun");
        time = 60;
        timeText = GameObject.Find("Time").GetComponent<Text>();
    }

    void Update()
    {
        if(!GameManager.gameManager.gameOver)
        {
            if (!start)
            {
                gun_m47.SetActive(false);
                gun_ak47.SetActive(false);
                gun_bitgun.SetActive(false);
            }
            else
            {
                switch (gun_name)
                {
                    case "ak47":
                        gun_ak47.SetActive(true);
                        break;

                    case "m47":
                        gun_m47.SetActive(true);
                        break;

                    case "bitgun":
                        gun_bitgun.SetActive(true);
                        break;
                }
                
                time -= Time.deltaTime;
                timeText.text = "0:" + time.ToString("F2");
                if (time < 0 || GameManager.gameManager.life == 0)
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
        GameManager.gameManager.life = 100;
        GvrCardboardHelpers.Recenter();
        GameObject cam = GameObject.Find("RawImage");
        cam.GetComponent<MoblieCam>().activeCameraTexture.Stop();
        SceneManager.LoadScene("Gun");
    }

    public void mainmenu()
    {
        Application.Quit();
    }
}
