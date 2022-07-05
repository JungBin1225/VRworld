using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public List<GameObject> lifeImage;
    void Start()
    {
        lifeImage.Add(GameObject.Find("Life_1"));
        lifeImage.Add(GameObject.Find("Life_2"));
        lifeImage.Add(GameObject.Find("Life_3"));
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 3; i++)
        {
            if(i <= GameManager.gameManager.life - 1)
            {
                lifeImage[i].SetActive(true);
            }
            else
            {
                lifeImage[i].SetActive(false);
            }
        }
    }
}
