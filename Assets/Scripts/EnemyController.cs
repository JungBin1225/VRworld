using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string type;
    public float life;
    public AudioClip deathAudio;

    private Animator animator;
    private float lifeTime;
    private float deathAnimTime;
    private AudioSource audioSource;
    private bool soundPlaying;
    private Vector3 target;
    private float degree;
    void Start()
    {
        switch (type)
        {
            case "enemy":
                life = 5;
                break;

            case "human":
                life = 1;
                break;
        }

        lifeTime = 10;
        deathAnimTime = 2.5f;

        animator = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
        soundPlaying = false;
        target = randomPos();
    }

    
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime < 0)
        {
            Destroy(this.gameObject);
        }

        if(life <= 0)
        {
            animator.SetBool("death", true);

            if(!soundPlaying)
            {
                audioSource.clip = deathAudio;
                audioSource.volume = 1.0f;
                audioSource.Play();

                soundPlaying = true;
            }

            lifeTime = 10;
            deathAnimTime -= Time.deltaTime;

            if(deathAnimTime < 0)
            {
                switch (type)
                {
                    case "enemy":
                        GameManager.gameManager.score++;
                        break;

                    case "human":
                        GameManager.gameManager.score--;
                        break;
                }

                Destroy(this.gameObject);
            }
        }

        transform.position += new Vector3((target.x - transform.position.x) * 0.001f, 0, (target.z - transform.position.z) * 0.001f);
        Vector3 dir = target - transform.position;
        degree = dir.magnitude;

        switch (type)
        {
            case "enemy":
                transform.LookAt(target);
                break;

            case "human":
                transform.LookAt(target);
                transform.rotation = Quaternion.Euler(0, transform.rotation.y - 90, 0);
                break;
        }

        if(degree < 0.5f)
        {
            target = randomPos();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag.Equals("bullet"))
        {
            if(life > 0)
            {
                life -= collision.collider.GetComponent<Shooting>().damage;
                Debug.Log(life);
                animator.SetTrigger("damaged");
            }
            
        }
    }

    private Vector3 randomPos()
    {
        Vector3 pos;
        float posX;
        float posZ;

        posX = Random.Range(transform.position.x - 5, transform.position.x + 5);
        posZ = Random.Range(transform.position.z - 5, transform.position.z + 5);

        pos = new Vector3(posX, 0, posZ);

        return pos;
    }
}
