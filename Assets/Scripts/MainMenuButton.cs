using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void OnStartClicked()
    {
        GameObject cam = GameObject.Find("RawImage");
        cam.GetComponent<MoblieCam>().activeCameraTexture.Stop();
        SceneManager.LoadScene("AvoidBall");
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
}
