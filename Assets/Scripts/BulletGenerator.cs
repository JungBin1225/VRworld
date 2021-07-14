using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletGenerator : MonoBehaviour
{
    //발사 효과음
    public GameObject bulletPrefeb;
    public GameObject gun;

    private GameObject muzzle;
    private GunStageManager stageManager;
    private float generateSpeed;
    private AudioSource audioSource;
    private GunStageManager manager;

    private int magazine;
    private int burst;
    private float reloadTime;
    private Image reloadGauge;
    private Text bulletNum;
    void Start()
    {
        manager = GameObject.Find("StageManager").GetComponent<GunStageManager>();
        muzzle = GameObject.Find("muzzle");
        stageManager = GameObject.Find("StageManager").GetComponent<GunStageManager>();
        generateSpeed = 0.3f;

        burst = 3;
        magazine = 20;
        reloadTime = 1.5f;
        reloadGauge = GameObject.Find("ReloadGauge").GetComponent<Image>();
        reloadGauge.fillAmount = 0;
        bulletNum = GameObject.Find("BulletNum").GetComponent<Text>();
    }


    void Update()
    {
        if (stageManager.start)
        {
            if (magazine == 0)
            {
                reload();
            }
            else
            {
                switch (manager.gun_name)
                {
                    case "ak47":
                        ak47_shoot();
                        break;

                    case "m47":
                        m47_shoot();
                        break;

                    case "bitgun":
                        bitgun_shoot();
                        break;
                }
                
            }

            bulletNum.text = magazine + " / 20";
        }
        else
        {
            bulletNum.text = "";
        }
    }

    void reload()
    {
        reloadTime -= Time.deltaTime;

        reloadGauge.fillAmount = 1 - (reloadTime / 1.5f);

        if(reloadTime < 0)
        {
            burst = 3;
            magazine = 20;
            reloadTime = 1.5f;
            reloadGauge.fillAmount = 0;
        }
    }

    void ak47_shoot()
    {
        audioSource = GameObject.Find("Gun_ak47").GetComponentInChildren<AudioSource>();

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefeb) as GameObject;
            bullet.transform.position = muzzle.transform.position;
            bullet.transform.rotation = muzzle.transform.rotation;
            bullet.GetComponent<Shooting>().damage = 0.7f;
            bullet.GetComponent<Shooting>().speed = 700;
            audioSource.Play();
            magazine--;
            burst--;
            generateSpeed = 0.1f;
        }

        if (Input.GetMouseButton(0))
        {
            generateSpeed -= Time.deltaTime;

            if (generateSpeed < 0)
            {
                GameObject bullet = Instantiate(bulletPrefeb) as GameObject;
                bullet.transform.position = muzzle.transform.position;
                bullet.transform.rotation = muzzle.transform.rotation;
                bullet.GetComponent<Shooting>().damage = 0.7f;
                bullet.GetComponent<Shooting>().speed = 700;
                audioSource.Play();

                if(burst <= 0)
                {
                    burst = 3;
                }

                magazine--;
                burst--;

                if(burst > 0)
                {
                    generateSpeed = 0.1f;
                }
                else
                {
                    generateSpeed = 0.4f;
                }
                
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            generateSpeed = 0.1f;
            burst = 3;
        }
    }

    void m47_shoot()
    {
        audioSource = GameObject.Find("Gun_m47").GetComponentInChildren<AudioSource>();

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefeb) as GameObject;
            bullet.transform.position = muzzle.transform.position;
            bullet.transform.rotation = muzzle.transform.rotation;
            bullet.GetComponent<Shooting>().damage = 1;
            bullet.GetComponent<Shooting>().speed = 500;
            audioSource.Play();
            magazine--;
            generateSpeed = 0.3f;
        }

        if (Input.GetMouseButton(0))
        {
            generateSpeed -= Time.deltaTime;

            if (generateSpeed < 0)
            {
                GameObject bullet = Instantiate(bulletPrefeb) as GameObject;
                bullet.transform.position = muzzle.transform.position;
                bullet.transform.rotation = muzzle.transform.rotation;
                bullet.GetComponent<Shooting>().damage = 1;
                bullet.GetComponent<Shooting>().speed = 500;
                audioSource.Play();
                magazine--;

                generateSpeed = 0.3f;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            generateSpeed = 0.3f;
        }
    }

    void bitgun_shoot()
    {
        audioSource = GameObject.Find("Gun_bitgun").GetComponentInChildren<AudioSource>();

        generateSpeed -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (generateSpeed < 0)
            {
                GameObject bullet = Instantiate(bulletPrefeb) as GameObject;
                bullet.transform.position = muzzle.transform.position;
                bullet.transform.rotation = muzzle.transform.rotation;
                bullet.GetComponent<Shooting>().damage = 1.8f;
                bullet.GetComponent<Shooting>().speed = 300;
                audioSource.Play();
                magazine--;
                generateSpeed = 0.5f;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (generateSpeed < 0)
            {
                GameObject bullet = Instantiate(bulletPrefeb) as GameObject;
                bullet.transform.position = muzzle.transform.position;
                bullet.transform.rotation = muzzle.transform.rotation;
                bullet.GetComponent<Shooting>().damage = 1.8f;
                bullet.GetComponent<Shooting>().speed = 300;
                audioSource.Play();
                magazine--;

                generateSpeed = 0.5f;
            }
        }
    }
}
