using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    PlatformBehaviour platform;

    bool isRed;
    //Collision player_Col;

    private void Start()
    {
        platform = gameObject.GetComponent<PlatformBehaviour>();
        //player_Col = GameObject.FindGameObjectWithTag("Player").GetComponent<Collision>();
    }

    private void Update()
    {
        isRed = PlatformBehaviour.isPlatformRed;
 
    }

    private void OnCollisionStay(Collision collision)
    {
        //Need to kill player when platform destroyed
        if ((collision.gameObject.name == "Player" || collision.gameObject.name == "Enemy" ))
        {
            if (isRed)
            {
                collision.gameObject.transform.SetParent(null);
            }
            else
            {
                collision.gameObject.transform.SetParent(transform);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

}
