using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutGenerator : MonoBehaviour
{
    public GameObject cutObject;
    public float time;
    public AudioSource source;
    public GameObject image;
    public bool isPortal = false;

    void Start()
    {
        time = Random.Range(1.5f, 3.5f);
        source = GameObject.Find("ResonanceAudioSource").GetComponent<AudioSource>();
        image = GameObject.Find("Image");
        image.SetActive(false);
    }

    void Update()
    {
        transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 0.2f);

        time -= Time.deltaTime;

        if(time < 0.8f)
        {
            image.SetActive(true);
        }

        if(time < 0)
        {
            GameObject cut = Instantiate(cutObject) as GameObject;
            cut.transform.position = transform.position;
            cut.transform.rotation = transform.rotation;

            source.Play();
            image.SetActive(false);
            time = Random.Range(2.9f, 4.5f);
        }
    }
}
