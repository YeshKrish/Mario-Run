using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public Transform player;

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
    }

    // Start is called before the first frame update 
    void Start()
    {
        CameraContoller.Instance.virtualCamera.Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
