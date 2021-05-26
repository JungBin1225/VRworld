using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public GameObject fadeUi;
    public Image fade;
    public GameObject message;
    public string moveTo;

    public bool fade_out = false;
    public bool fade_in = false;

    void Start()
    {
        fadeUi = GameObject.Find("Fade");
        fade = fadeUi.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fade_out)
        {
            if (fade.color.a < 1)
            {
                fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fade.color.a + (2 * Time.deltaTime));
            }
            else
            {
                message.SetActive(true);
            }
            
            /*{
                //GameManager.gameManager.initArray();
                //SceneManager.LoadScene(moveTo);
            }*/
        }

        if(fade_in)
        {
            if (fade.color.a > 0)
            {
                fade_out = false;
                message.SetActive(false);
                fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fade.color.a - (0.5f * Time.deltaTime));

                if (fade.color.a > 0.95f)
                {
                    GameManager.gameManager.gameOver = false;
                    GameManager.gameManager.life = 3;
                    GvrCardboardHelpers.Recenter();
                }
            }
            else
            {
                fade_in = false;
            }
        }
    }

    public void OnYesClicked()
    {
        fade_in = true;
    }

    public void OnNoClicked()
    {
        GameObject cam = GameObject.Find("RawImage");
        cam.GetComponent<MoblieCam>().activeCameraTexture.Stop();
        SceneManager.LoadScene("MainMenu");
    }
}
