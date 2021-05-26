using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureManager : MonoBehaviour
{
    public Capture capture;
    public int page = 1;

    void Start()
    {
        capture = GameObject.Find("PictureCanvas").GetComponent<Capture>();
    }

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = null;
            transform.GetChild(i).GetComponent<Image>().color = Color.clear;
        }

        if(capture.picture.Count != 0)
        {
            for (int i = 0; i < 4; i++)
            {
                Rect rect = new Rect(0, 0, capture.picture[i].width, capture.picture[i].height);
                transform.GetChild(i).GetComponent<Image>().sprite = Sprite.Create(capture.picture[i + ((page - 1) * 4)], rect, new Vector2(0, 0));
                transform.GetChild(i).GetComponent<Image>().color = Color.white;

                if ((i + ((page - 1) * 4) + 1) == capture.picture.Count)
                {
                    i = 4;
                }
            }
        }
    }

    public void next()
    {
        if(capture.picture.Count == 0 || (capture.picture.Count - 1) / 4 == (page - 1))
        {
            page = 1;
        }
        else
        {
            page++;
        }
    }
}
