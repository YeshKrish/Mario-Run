using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private void Update()
    {
        if (this.transform.position.y < -0.001f)
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void OnDestroy()
    {

        transform.parent.GetComponent<Enemy_Controller>().CheckForDestroy(Enemy_Controller.isCollidingWithPlayer);       
    }
}
