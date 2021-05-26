using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    public enum MoveType
    {
        LOOK_AT,
        DAYDREAM
    }
    public MoveType moveType = MoveType.LOOK_AT;
    public float speed = 1.0f;
    public float damping = 3.0f;
    public Vector3 dir;

    private Transform tr;
    private CharacterController cc;
    private Transform camTr;

    private int nextIdx = 1;

    public List<bool> isStop;
    public bool isWalking = true;

    private Cliker clicker = new Cliker();

    void Start()
    {
        tr = GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
        camTr = Camera.main.GetComponent<Transform>();
        GameObject wayPointGroup = GameObject.Find("WayPointGroup");
    }

    void Update()
    {
        isStop.Clear();

        for (int i = 0; i < 10; i++)
        {
            if(GameManager.gameManager.distance[i] && GameManager.gameManager.stop[i])
            {
                isStop.Add(true);
            }
            else
            {
                isStop.Add(false);
            }
        }

        if (isStop.Contains(true))
        {
            return;
        }

        if(clicker.clicked())
        {
            isWalking = !isWalking;
        }

        if(isWalking)
        {
            switch (moveType)
            {

                case MoveType.LOOK_AT:
                    MoveLookAt(1);
                    break;

                case MoveType.DAYDREAM:
                    break;
            }
        }
    }

    void MoveLookAt(int facing)
    {
        Vector3 heading = camTr.forward;
        heading.y = 0.0f;

        Debug.DrawRay(tr.position, heading.normalized * 1.0f, Color.red);
        cc.SimpleMove(heading * speed * facing);
    }
}
