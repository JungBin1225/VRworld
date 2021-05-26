using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image fade;
    void Start()
    {
        fade = GetComponent<Image>();
    }

    
    void Update()
    {
        if(fade.color.a > 0)
        {
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fade.color.a - (0.5f * Time.deltaTime));
        }
    }
}
