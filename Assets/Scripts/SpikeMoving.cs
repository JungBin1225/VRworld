using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMoving : MonoBehaviour
{
    public GameObject player;
    public Vector3 target;
    public AudioSource sound;
    public bool play;
    float lifeTime = 2.8f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position;
        sound = GameObject.Find("ResonanceAudioSource").GetComponent<AudioSource>();
        play = false;
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;

        this.transform.position -= (this.transform.position - new Vector3(target.x, 1.8f, target.z)) * (Time.deltaTime * 3f);

        if (lifeTime < 0)
        {
            GameManager.gameManager.score += 1;
            Destroy(this.gameObject);
        }

        if (lifeTime < 2.1f && !play)
        {
            sound.Play();
            play = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        GameManager.gameManager.life -= 1;


        if (GameManager.gameManager.life == 0)
        {
            GameManager.gameManager.gameOver = true;
            GameManager.gameManager.score = 0;
            GameObject spikeGenerator = GameObject.Find("SpikeGenerator");
            FadeOut fadeOut = spikeGenerator.GetComponent<FadeOut>();
            fadeOut.fade_out = true;
        }
    }
}
