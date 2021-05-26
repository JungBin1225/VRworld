using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VrOnOff : MonoBehaviour
{
    public static VrOnOff instance;

    void Awake()
    {
        enableVr();
        //or
        //disableVR();
    }

    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    IEnumerator LoadDevice(string newDevice, bool enable)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = enable;
    }

    void enableVr()
    {
        StartCoroutine(LoadDevice("cardboard", true));
    }

    void disableVr()
    {
        StartCoroutine(LoadDevice("", false));
    }
}
