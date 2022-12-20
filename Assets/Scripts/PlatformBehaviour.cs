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
    public static bool isPlatformRed = false;

    StickyPlatform sticky;

    Vector3 shrinkOriginalSize;

    Transform platformShrink;

    [SerializeField] 
    Renderer platformColor;

    Finish finish;

    string endPlatformName = "Endline";

    List<Collider> collidingObjects;

    private void Start()
    {
        platformShrink = GameObject.FindGameObjectWithTag("EndLine").transform;

        finish = GameObject.FindGameObjectWithTag("FinishLine").GetComponent<Finish>();

        sticky = gameObject.GetComponent<StickyPlatform>();

        shrinkOriginalSize = platformShrink.localScale;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        isPlatformBurst = Mathf.FloorToInt(Time.time) % 8 == 0;

        isPlatformShrinking = Mathf.FloorToInt(Time.time) % 3 == 0;

        //Hurdle 2: After 3sec shrink the platform and resize to original
        if (isPlatformShrinking && currentTime >= togglePlatformSize && !finish.isFinishLine && GameManager.Instance.level >= 3)
        {
            PlatformShrinking();
        }
        else
        {
            platformShrink.localScale = shrinkOriginalSize;
        }

        Debug.Log("Platform Red" + isPlatformRed);
        //Debug.Log(currentTime);
    }

    private void OnTriggerStay(Collider other)
    {
        //Hurdle 1: Chnage the color of platform to red and burst after 3 seconds
        if(GameManager.Instance.level >= 3)
        {
            Debug.Log(transform.parent.parent.name + " " + endPlatformName);
            Debug.Log(PlayerPrefs.GetInt("NextLevelPromotion"));
            if (other.gameObject.CompareTag("Player") && isPlatformBurst && currentTime >= togglePlatformColor && transform.parent.parent.name != endPlatformName)
            {
                //GetComponent<StickyPlatform>().enabled = false;
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
        Transform transform = this.GetComponentInParent<Transform>();
        Destroy(transform.parent.gameObject);
       
    }

    void PlatformShrinking()
    {
        platformShrink.localScale = new Vector3(1.0f, 1.0f, 0.5f);    
    }

}
