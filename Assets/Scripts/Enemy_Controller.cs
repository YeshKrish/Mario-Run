using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] GameObject burst;

    private void Start()
    {
        
    }

    private void Update()
    {  

        if(this.transform.position.y < -2.5f)
        {
            Instantiate(burst, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("No of children:" + this.transform.GetComponentInChildren<Collider>().isTrigger);
        //foreach (Collider collidingObjects in this.GetComponents<Collider>())
        //{
        //    Debug.Log("I am colliding with" + collidingObjects.name);
        //}

        Debug.Log("I am in Trigger" + other.gameObject.name);
    }
}
    
        