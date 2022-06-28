using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public GameObject lifeImage;
    public Text lifeText;
    void Start()
    {
        lifeImage = GameObject.Find("Life");
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeImage.GetComponent<Image>().fillAmount = GameManager.gameManager.life / 100f;
        lifeText.text = GameManager.gameManager.life + " / 100";
    }
}
