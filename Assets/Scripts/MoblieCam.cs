using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class MoblieCam : MonoBehaviour
{
    public WebCamDevice backCameraDevice;
    public WebCamDevice activeCameraDevice;

    public WebCamTexture backCameraTexture;
    public WebCamTexture activeCameraTexture;

    RawImage rawImage;

    void Awake()
    {
        rawImage = GetComponent<RawImage>();

        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }

        if (WebCamTexture.devices.Length == 0)
        {
            Debug.Log("No devices cameras found");

            return;
        }

        backCameraDevice = WebCamTexture.devices.First();

        backCameraTexture = new WebCamTexture(backCameraDevice.name, 2400, 1080);

        backCameraTexture.filterMode = FilterMode.Trilinear;

        if (activeCameraTexture != null)
        {
            activeCameraTexture.Stop();
        }
        activeCameraTexture = backCameraTexture;
        activeCameraDevice = WebCamTexture.devices.FirstOrDefault(device => device.name == backCameraTexture.deviceName);



        rawImage.texture = activeCameraTexture;
        rawImage.material.mainTexture = activeCameraTexture;
        activeCameraTexture.Play();

        if (backCameraTexture.width < 100)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
