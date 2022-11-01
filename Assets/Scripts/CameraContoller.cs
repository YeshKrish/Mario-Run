using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraContoller : MonoBehaviour
{
    [SerializeField] Vector3 offset = new Vector3(0f, 4.5f, -13f);

    public Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
       
    }
}
