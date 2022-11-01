using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraContoller : MonoBehaviour
{
    public static CameraContoller Instance;

    [HideInInspector]
    public CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        GameObject vCamObject = GameObject.FindWithTag("VirtualCamera");

        virtualCamera = vCamObject.GetComponent<CinemachineVirtualCamera>();
    }

}
