using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class CameraVR : MonoBehaviour
{
    [SerializeField] private float m_RenderScale = 1f;
    // Use this for initialization

    private bool gyroEnabled;
    private Gyroscope gyroscope;
    private GameObject cameraContainer;
    private Quaternion rot;

    void Start()
    {
        UnityEngine.XR.XRSettings.eyeTextureResolutionScale = m_RenderScale;
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        gyroEnabled = EnableGyro();
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyroscope.attitude * rot;
        }
    }
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;
    }


}