using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookObject : MonoBehaviour
{
    public GameObject stage;
    public GameObject button;

    public bool isLook;
    private float time = 1.5f;
    void Start()
    {
        stage = GameObject.Find("StageManager");
    }

    void Update()
    {
        if(isLook)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                if (stage.GetComponent<MusicRoom>().state.Equals("Select"))
                {
                    button.SetActive(true);
                }
            }
        }
        else
        {
            time = 1.5f;
        }

        if(stage.GetComponent<MusicRoom>().state.Equals("Select"))
        {
            this.gameObject.GetComponent<SphereCollider>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }

    public void OnLookItemBox(bool isLookAt)
    {
        isLook = isLookAt;
        Debug.Log(isLookAt);
    }
}
