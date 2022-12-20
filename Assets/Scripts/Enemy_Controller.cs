using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] GameObject burst;

    [SerializeField] GameObject plasma;

    [HideInInspector]
    public static bool isCollidingWithPlayer = false;

    //[SerializeField] Transform follow = null;

    //private Vector3 originalLocalPosition;
    //private Quaternion originalLocalRotation;


    //private void Awake()
    //{
    //    originalLocalPosition = follow.localPosition;
    //    originalLocalRotation = follow.localRotation;
    //}

    private void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log("Player collision" + isCollidingWithPlayer);

        //Debug.Log("ChildCount" + transform.childCount);
        //if (this.transform.position.y < -2.5f)
        //{
        //    Instantiate(burst, transform.position, transform.rotation);
        //    Destroy(this.gameObject);
        //}
    }

    public void CheckForDestroy(bool isPlayer)
    {
        Debug.Log("Player collision" + isCollidingWithPlayer);
        if (!isPlayer)
        {
            Instantiate(burst, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else if(isPlayer)
        {
            Instantiate(plasma, transform.position, transform.rotation);
            isCollidingWithPlayer = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ContactPoint[] contactPoints = collision.contacts;
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log("I am colliding with:" + collision.gameObject.CompareTag("Player"));
            if (collision.gameObject.CompareTag("Player"))
            {
                isCollidingWithPlayer = true;
                Debug.Log("Player's collision" + isCollidingWithPlayer);
            }
        }

        //if(collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("MovingPlatform"))
        //{
        //    Instantiate(burst, transform.position, transform.rotation);
        //    Destroy(this.gameObject);
        //}

        //for (int i = 0; i < contactPoints.Length; i++)
        //{
        //    Debug.Log(contactPoints[i].thisCollider.name);
        //}
    }

}
    
        