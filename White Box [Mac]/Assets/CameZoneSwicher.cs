using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameZoneSwicher : MonoBehaviour
{
    public string triggerTag;
    public CinemachineVirtualCamera PrimaryCamera;
    public CinemachineVirtualCamera[] virtualCameras;

    private void Start()
    {
        SwitchToCamera(PrimaryCamera);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(triggerTag))
        {
            CinemachineVirtualCamera targetCamera = collision.GetComponentInChildren<CinemachineVirtualCamera>(); // Changed "other" to "collision"
            SwitchToCamera(targetCamera);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(triggerTag))
        {
            SwitchToCamera(PrimaryCamera);
        }
    }

    private void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        foreach (CinemachineVirtualCamera camera in virtualCameras)
        {
            camera.enabled = camera == targetCamera;
        }
    }
}
