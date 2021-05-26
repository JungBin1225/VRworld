using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookKey : MonoBehaviour
{
    public GameObject player;
    public GameObject key;
    public int num;
    public Vector3 dir;

    public float initTime = 3;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dir = player.transform.position - this.gameObject.transform.position;

        if(dir.magnitude < 3)
        {
            GameManager.gameManager.distance[num] = true;
        }
        else if (dir.magnitude >= 3 && dir.magnitude <= 5)
        {
            GameManager.gameManager.distance[num] = false;
        }

        if(GameManager.gameManager.distance[num] && GameManager.gameManager.stop[num])
        {
            if(initTime > 0)
            {
                initTime -= 1 * Time.deltaTime;
            }
            else
            {
                Debug.Log(GameManager.gameManager.inventory.Count.ToString());
                GameManager.gameManager.inventory.Add(key);
                GameManager.gameManager.distance[num] = false;
                GameManager.gameManager.stop[num] = false;
                this.gameObject.SetActive(false);
                
            }
        }
        else
        {
            initTime = 3;
        }

        if(GameManager.gameManager.inventory.Contains(key))
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OnLookItemBox(bool isLookAt)
    {
        Debug.Log(isLookAt);
        GameManager.gameManager.stop[num] = isLookAt;
    }
}
