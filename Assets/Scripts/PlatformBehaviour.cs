using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    float currentTime;
    bool isPlatformBurst;
    float togglePlatformColor = 8f;

    [SerializeField] Renderer platformColor;

    private void Update()
    {
        currentTime += Time.deltaTime;
        isPlatformBurst = Mathf.FloorToInt(Time.time) % 8 == 0;
        //Debug.Log(currentTime);
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Player") && isPlatformBurst && currentTime > togglePlatformColor)
    //    {
    //        currentTime = 0f;
    //        Debug.Log(currentTime);
    //        Debug.Log("Changing Color");
    //        platformColor.material.color = Color.red;
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBottom"))
        {
            Debug.Log("I have enemy");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isPlatformBurst && currentTime > togglePlatformColor)
        {
            currentTime = 0f;
            //Debug.Log(currentTime);
            Debug.Log("Changing Color");
            platformColor.material.color = Color.red;
            Invoke("DestroyPlatform", 3f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentTime = 0f;
    }

    void DestroyPlatform()
    {
       // this.GetComponentInParent<MeshRenderer>().enabled = false;
        Transform transform = this.GetComponentInParent<Transform>();
        Destroy(transform.parent.gameObject);
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    currentTime = 0f;
    //}

}
