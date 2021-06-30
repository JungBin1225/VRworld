using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string type;
    public int life;

    private float lifeTime;
    void Start()
    {
        switch (type)
        {
            case "enemy":
                life = 5;
                Debug.Log("5");
                break;

            case "human":
                life = 1;
                Debug.Log("1");
                break;
        }

        lifeTime = 10;
    }

    
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime < 0)
        {
            Destroy(this.gameObject);
        }

        if(life == 0)
        {
            Destroy(this.gameObject);

            switch (type)
            {
                case "enemy":
                    GameManager.gameManager.score++;
                    break;

                case "human":
                    GameManager.gameManager.score--;
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag.Equals("bullet"))
        {
            life--;
        }
    }
}
