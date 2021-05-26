using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCollider : MonoBehaviour
{
    public Vector3 exit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionExit(Collision collision)
    {
        ContactPoint[] con = new ContactPoint[1];
        collision.GetContacts(con);

        Debug.Log(con.Length.ToString());
        Debug.Log(con[0].point.ToString());

        exit = con[0].point;
    }
}
