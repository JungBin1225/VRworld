using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public GameObject player;
    public GameObject key;
    public int num;
    public Vector3 dir;


    public string moveTo;
    public FadeOut fadeout;

    public float initTime = 3;

    void Start()
    {
        player = GameObject.Find("Player");
        fadeout = GetComponent<FadeOut>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = player.transform.position - this.gameObject.transform.position;

        if (dir.magnitude < 3)
        {
            GameManager.gameManager.distance[num] = true;
        }
        else if (dir.magnitude >= 3 && dir.magnitude <= 5)
        {
            GameManager.gameManager.distance[num] = false;
        }

        if (GameManager.gameManager.distance[num] && GameManager.gameManager.stop[num])
        {
            if (initTime > 0)
            {
                initTime -= 1 * Time.deltaTime;
            }
            else
            {
                fadeout.moveTo = moveTo;
                fadeout.fade_out = true;
            }
        }
        else
        {
            initTime = 3;
        }
    }

    public void OnLookItemBox(bool isLookAt)
    {
        Debug.Log(isLookAt);
        GameManager.gameManager.stop[num] = isLookAt;
    }
}
