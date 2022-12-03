using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    public Transform playerPos;

    private void OnCollisionStay(Collision collision)
    {
        //Need to kill player when platform destroyed
        if ((collision.gameObject.name == "Player" || collision.gameObject.name == "Enemy" ))
        {
            collision.gameObject.transform.SetParent(transform); 

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
