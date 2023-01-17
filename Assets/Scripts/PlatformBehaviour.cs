using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class PlatformBehaviour : MonoBehaviour
{
    [SerializeField]
    private const string GROUND_LAYER = "Platform";

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

    //GameObject platform;

    Finish finish;

    string endPlatformName = "Endline";

    List<Collider> collidingObjects;

    Enemy_Controller enemy;

    private void Start()
    {
        //platform = GameObject.FindGameObjectWithTag("Platform");

        platformShrink = GameObject.FindGameObjectWithTag("EndLine").transform;

        finish = GameObject.FindGameObjectWithTag("FinishLine").GetComponent<Finish>();

        sticky = gameObject.GetComponent<StickyPlatform>();

        shrinkOriginalSize = platformShrink.localScale;

    }

    private void Update()
    {
        Debug.DrawRay(this.transform.parent.position, Vector3.up, Color.red);


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
    }

    private void OnTriggerStay(Collider other)
    {
        //Hurdle 1: Chnage the color of platform to red and burst after 3 seconds
        if(GameManager.Instance.level >= 3)
        {
            if (other.gameObject.CompareTag("Player") && isPlatformBurst && currentTime >= togglePlatformColor && transform.parent.parent.name != endPlatformName)
            {
                //GetComponent<StickyPlatform>().enabled = false;
                isPlatformRed = true;
                currentTime = 0f;
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
        //RaycastHit _hit;

        //Physics.Raycast(this.transform.position, Vector3.down, out _hit);
        //Debug.Log("I hitted:" + _hit.transform.gameObject.name);
        //enemy = _hit.transform.parent.gameObject.GetComponent<Enemy_Controller>();
        //Transform transform = this.GetComponentInParent<Transform>();
        //Destroy(transform.parent.gameObject);
        transform.parent.gameObject.SetActive(false);
        //enemy.DestroyEnemy();
    }

    void PlatformShrinking()
    {
        platformShrink.localScale = new Vector3(1.0f, 1.0f, 0.5f);    
    }

}
