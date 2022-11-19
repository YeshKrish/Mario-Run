using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    private void Update()
    {
        if(this.transform.position.y < -2.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
    
    