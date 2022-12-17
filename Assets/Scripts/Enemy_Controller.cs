using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] GameObject burst;

    private void Update()
    {  

        if(this.transform.position.y < -2.5f)
        {
            Instantiate(burst, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
    
    