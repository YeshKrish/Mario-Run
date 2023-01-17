using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] GameObject burst;

    [SerializeField] GameObject plasma;

    [HideInInspector]
    public static bool isCollidingWithPlayer = false;

    [SerializeField]
    private const string GROUND_LAYER = "Ground";

    //[SerializeField] Transform follow = null;

    //private Vector3 originalLocalPosition;
    //private Quaternion originalLocalRotation;


    //private void Awake()
    //{
    //    originalLocalPosition = follow.localPosition;
    //    originalLocalRotation = follow.localRotation;
    //}

    //Need to impleted in future

    //public void DestroyEnemy()
    //{
    //    Debug.Log("Destroyed Enemy Called");
    //    RaycastHit _hit;
    //    Debug.Log("Gameobj name:" + transform.gameObject.name);
    //    bool isTouchingPlatform = Physics.Raycast(transform.position, Vector3.down, out _hit, 1000);
    //    Debug.Log("Is touching" + isTouchingPlatform + "hit info:" + _hit.point);
    //    if (isTouchingPlatform)
    //    {
    //        Debug.Log("My name is:" + this.gameObject.name);
    //        this.gameObject.SetActive(false);
    //        GameObject plasmaInstance = (GameObject)Instantiate(plasma, transform.position, transform.rotation);
    //        Destroy(plasmaInstance, 3f);
    //    }
    //}

    private void Update()
    {
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
            GameObject _burstInstance = (GameObject)Instantiate(burst, transform.position, transform.rotation);
            Destroy(_burstInstance, 3f);
            Destroy(this.gameObject);
        }
        else if(isPlayer)
        {
            GameObject _plasmaInstance = (GameObject)Instantiate(plasma, transform.position, transform.rotation);
            Destroy(_plasmaInstance, 3f);
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
    
        