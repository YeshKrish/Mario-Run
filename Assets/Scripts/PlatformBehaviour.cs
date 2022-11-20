using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    float currentTime;
    bool isPlatformBurst;
    float togglePlatformColor = 8f;
    static bool isEndline = false;

    [SerializeField] Renderer platformColor;

    string endPlatformName = "Endline";

    private void Update()
    {
        currentTime += Time.deltaTime;
        isPlatformBurst = Mathf.FloorToInt(Time.time) % 8 == 0;
        //Debug.Log(currentTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(transform.parent.name);
        if (collision.gameObject.CompareTag("Player") && transform.parent.name == endPlatformName)
        {
            isEndline = true;

        }
        else
        {
            isEndline = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(isEndline);
        if (other.gameObject.CompareTag("Player") && isPlatformBurst && currentTime >= togglePlatformColor && !isEndline)
        {

            Debug.Log(currentTime);
            currentTime = 0f;
            Debug.Log(currentTime);
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


}
