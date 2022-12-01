using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    float currentTime;
    bool isPlatformBurst;
    float togglePlatformColor = 8f;
    float togglePlatformSize = 3f;
    //bool isEndline = false;
    bool isPlatformShrinking;

    [HideInInspector]
    public bool isPlatformRed = false;
    Vector3 shrinkOriginalSize;

    Transform platformShrink;

    [SerializeField] 
    Renderer platformColor;

    Finish finish;

    string endPlatformName = "Endline";

    private void Start()
    {
        platformShrink = GameObject.FindGameObjectWithTag("EndLine").transform;

        finish = GameObject.FindGameObjectWithTag("FinishLine").GetComponent<Finish>();

        shrinkOriginalSize = platformShrink.localScale;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        isPlatformBurst = Mathf.FloorToInt(Time.time) % 8 == 0;

        isPlatformShrinking = Mathf.FloorToInt(Time.time) % 3 == 0;

        Debug.Log(platformShrink.localScale + " " + finish.isFinishLine);

        if (isPlatformShrinking && currentTime >= togglePlatformSize && !finish.isFinishLine)
        {
            PlatformShrinking();
        }
        else
        {
            platformShrink.localScale = shrinkOriginalSize;
        }

        Debug.Log("Platform Dead" + isPlatformRed);
        //Debug.Log(currentTime);
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    Debug.Log(transform.parent.name + " " + endPlatformName);
    //    if (collision.gameObject.CompareTag("Player") && transform.parent.name == endPlatformName)
    //    {
    //        isEndline = true;
    //        Debug.Log("Finsh Line:" + isEndline);

    //    }
    //    else
    //    {
    //        isEndline = false;
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if(GameManager.Instance.level >= 3)
        {
            Debug.Log(transform.parent.parent.name + " " + endPlatformName);
            Debug.Log(PlayerPrefs.GetInt("NextLevelPromotion"));
            if (other.gameObject.CompareTag("Player") && isPlatformBurst && currentTime >= togglePlatformColor && transform.parent.parent.name != endPlatformName)
            {
                isPlatformRed = true;
                Debug.Log(currentTime);
                currentTime = 0f;
                Debug.Log(currentTime);
                Debug.Log("Changing Color");
                platformColor.material.color = Color.red;
                Invoke("DestroyPlatform", 3f);
            }
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

    void PlatformShrinking()
    {
        platformShrink.localScale = new Vector3(1.0f, 1.0f, 0.5f);    
    }

}
