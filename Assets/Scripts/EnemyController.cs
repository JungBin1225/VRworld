using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string type;
    public float life;
    public AudioClip deathAudio;
    public GameObject bombEffect;

    private WeaponDamage damage;
    private GameObject player;
    private Animator animator;
    private float lifeTime;
    private float deathAnimTime;
    private float damageAnimTime;
    private AudioSource audioSource;
    private bool soundPlaying;
    private Vector3 target;
    private float degree;
    private float speed;
    private bool isAttack;

    void Start()
    {
        life = 5;

        lifeTime = 10;
        deathAnimTime = 2.5f;
        damageAnimTime = 1.0f;

        damage = GetComponentInChildren<WeaponDamage>();
        switch (type)
        {
            case "Enemy":
                damage.damage = 7;
                speed = 0.006f;
                break;
            case "Enemy_1":
                damage.damage = 20;
                speed = 0.004f;
                break;
            case "Enemy_2":
                damage.damage = 10;
                speed = 0.01f;
                break;
            case "Enemy_3":
                damage.damage = 15;
                speed = 0.004f;
                break;
            case "Enemy_4":
                damage.damage = 13;
                speed = 0.008f;
                break;
            case "Enemy_5":
                damage.damage = 10;
                speed = 0.01f;
                break;
        }

        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
        soundPlaying = false;
        target = player.transform.position;
        isAttack = false;
    }

    
    void Update()
    {
        if (life <= 0 || lifeTime < 0)
        {
            animator.SetBool("death", true);

            if(!soundPlaying)
            {
                audioSource.clip = deathAudio;
                audioSource.volume = 1.0f;
                audioSource.Play();

                soundPlaying = true;
            }

            deathAnimTime -= Time.deltaTime;

            if(deathAnimTime < 0)
            {
                if(life <= 0)
                {
                    GameManager.gameManager.score++;
                }

                switch (type)
                {
                    case "Enemy_1":
                        GameObject bomb = Instantiate(bombEffect) as GameObject;
                        bomb.transform.position = this.transform.position;
                        break;
                }

                Destroy(this.gameObject);
            }
        }
        
        Vector3 dir = target - transform.position;
        degree = dir.magnitude;
        transform.LookAt(target);

        if (degree < 2.7f)
        {
            lifeTime -= Time.deltaTime;
        }

        if (damageAnimTime < 0)
        {
            if (degree < 2.7f)
            {
                animator.SetBool("attack", true);

                if(isAttack && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    damage.damaged = false;
                }
                isAttack = animator.GetCurrentAnimatorStateInfo(0).IsName("Attack");

            }
            else
            {
                if(deathAnimTime == 2.5f)
                {
                    transform.position += new Vector3((target.x - transform.position.x) * speed, 0, (target.z - transform.position.z) * speed);
                }
            }
        }
        else
        {
            damageAnimTime -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag.Equals("bullet"))
        {
            if(life > 0)
            {
                life -= collision.collider.GetComponent<Shooting>().damage;
                animator.SetTrigger("damaged");
                damageAnimTime = 1;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("bullet"))
        {
            if (life > 0)
            {
                life -= other.GetComponent<Shooting>().damage;
                animator.SetTrigger("damaged");
                damageAnimTime = 1;
            }

        }
    }
}
