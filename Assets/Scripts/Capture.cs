using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{
    MoblieCam cam;
    public List<Texture2D> picture;

    public float time = 5f;
    public bool timer = false;

    public AudioSource shutterSound;

    void Start()
    {
        cam = GameObject.Find("RawImage").GetComponent<MoblieCam>();
        shutterSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(timer)
        {
            time -= Time.deltaTime;

            if(time < 0)
            {
                Texture2D photo = new Texture2D(cam.activeCameraTexture.width, cam.activeCameraTexture.height);

                photo.SetPixels(cam.activeCameraTexture.GetPixels());
                photo.Apply();
                picture.Add(photo);

                shutterSound.Play();

                timer = false;
                time = 5f;
            }
        }
    }

    public void shutter()
    {
        timer = true;
    }
}
