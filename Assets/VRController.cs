using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRController : MonoBehaviour
{
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Pulled Trigger Button");
        }

        if(OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            Vector2 touchPos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            Debug.LogFormat("Touch position = {0}", touchPos);
        }
    }
}
