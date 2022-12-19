using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] GameObject burst;

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
        Debug.Log("ChildCount" + transform.childCount);
        if (this.transform.position.y < -2.5f)
        {
            Instantiate(burst, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    public void CheckForDestroy()
    {
        Debug.Log("I am in CheckDest");
        Instantiate(burst, transform.position, transform.rotation);
        Destroy(this.gameObject);

    }

    private void OnCollisionExit(Collision collision)
    {
        //ContactPoint[] contactPoints = collision.contacts;
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log("I am colliding with:" + collision.gameObject.name);
        }

        if(collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("MovingPlatform"))
        {
            Instantiate(burst, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        //for (int i = 0; i < contactPoints.Length; i++)
        //{
        //    Debug.Log(contactPoints[i].thisCollider.name);
        //}
    }
}
    
        