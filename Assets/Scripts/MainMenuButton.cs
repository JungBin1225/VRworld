using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    public List<string> mapNameList;
    public List<Sprite> mapImageList;

    public GameObject mapImage;
    public GameObject mapName;

    private int num = 0;

    void Start()
    {
        mapImage = GameObject.Find("MapImage");
        mapName = GameObject.Find("MapName");
    }

    void Update()
    {
        mapImage.GetComponent<Image>().sprite = mapImageList[num];
        mapName.GetComponent<Text>().text = mapNameList[num];
    }

    public void OnStartClicked()
    {
        GameObject cam = GameObject.Find("RawImage");
        cam.GetComponent<MoblieCam>().activeCameraTexture.Stop();
        SceneManager.LoadScene(mapNameList[num]);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }

    public void OnRightClicked()
    {
        if(num == mapNameList.Count - 1)
        {
            num = 0;
        }
        else
        {
            num++;
        }
    }

    public void OnLeftClicked()
    {
        if(num == 0)
        {
            num = mapNameList.Count - 1;
        }
        else
        {
            num--;
        }
    }
}
