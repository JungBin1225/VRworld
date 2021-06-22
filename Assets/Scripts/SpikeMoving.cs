using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMoving : MonoBehaviour
{
    public GameObject player;
    public Vector3 target;
    public bool play;
    public AudioSource sound;

    public string type;

    float lifeTime = 2.8f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        play = false;
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;

        this.transform.position -= (this.transform.position - new Vector3(target.x, 1.8f, target.z)) * (Time.deltaTime * (3f + (0.1f * GameManager.gameManager.avoidNum)));

        if (lifeTime < 0)
        {
            if (type == "Soccer Ball spike")
            {
                GameManager.gameManager.score += 1;
            }
            GameManager.gameManager.avoidNum++;
            Destroy(this.gameObject);
        }

        if (lifeTime < 2.1f && !play)
        {
            if(this.transform.position.x - player.transform.position.x > 1)
            {
                sound = GameObject.Find("ResonanceAudioSource2").GetComponent<AudioSource>();
            }
            else if(this.transform.position.x - player.transform.position.x < -1)
            {
                sound = GameObject.Find("ResonanceAudioSource3").GetComponent<AudioSource>();
            }
            else
            {
                sound = GameObject.Find("ResonanceAudioSource1").GetComponent<AudioSource>();
            }
            sound.Play();
            play = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(type == "Soccer Ball spike")
        {
            GameManager.gameManager.life -= 1;
        }
        else if(type == "Billiards Ball spike")
        {
            if(GameManager.gameManager.life < 3)
            {
                GameManager.gameManager.life += 1;
            }
        }


        if (GameManager.gameManager.life == 0)
        {
            GameManager.gameManager.gameOver = true;
            GameManager.gameManager.score = 0;
            GameObject spikeGenerator = GameObject.Find("SpikeGenerator");
            FadeOut fadeOut = spikeGenerator.GetComponent<FadeOut>();
            fadeOut.fade_out = true;
        }

        GameManager.gameManager.avoidNum++;

        Destroy(this.gameObject);
    }
}
