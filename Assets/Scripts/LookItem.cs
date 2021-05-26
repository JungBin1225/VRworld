using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookItem : MonoBehaviour
{
    public GameObject player;
    public GameObject key;
    public Vector3 dir;
    public int num;
    private Animator anim;
    private readonly int hashIsOpen = Animator.StringToHash("IsOpen");

    public GameObject canvas;

    private float closeTime = 5;

    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        dir = player.transform.position - this.gameObject.transform.position;

        if (dir.magnitude < 3)
        {
            GameManager.gameManager.distance[num] = true;
        }
        else if(dir.magnitude >= 3 && dir.magnitude <= 5)
        {

            GameManager.gameManager.distance[num] = false;
        }

        if (GameManager.gameManager.distance[num] && GameManager.gameManager.stop[num])
        {
            closeTime = 5;
            canvas.SetActive(true);
        }

        if (canvas.activeSelf == true)
        {
            closeTime -= 1 * Time.deltaTime;
            if (closeTime < 0)
            {
                closeTime = 5;
                canvas.SetActive(false);
            }
        }
    }
    public void OnLookItemBox(bool isLookAt)
    {
        Debug.Log(isLookAt);
        GameManager.gameManager.stop[num] = isLookAt;
    }

    public void OnBoxOpen(bool isOpen)
    {
        if (GameManager.gameManager.inventory.Contains(key))
        {
            anim.SetBool(hashIsOpen, isOpen);
        }
    }
}
