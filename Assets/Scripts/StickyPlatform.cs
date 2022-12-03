using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    public Transform playerPos;

    [SerializeField]
    PlatformBehaviour platform;

    private void OnCollisionStay(Collision collision)
    {
        //Need to kill player when platform destroyed
        if ((collision.gameObject.name == "Player" || collision.gameObject.name == "Enemy" ) && PlatformBehaviour.isPlatformRed == false)
        {
            collision.gameObject.transform.SetParent(transform); 

        }
        //Need to work
        else if(PlatformBehaviour.isPlatformRed == true)
        {
            Destroy(this);
            //Invoke("RemoveStickyPlayer", 1f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    void RemoveStickyPlayer()
    {
       // this.enabled = false;
    }
}
