using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{

    void Update()
    {
        RotateCoins();
    }

    void RotateCoins()
    {
        transform.Rotate(new Vector3(0f, 0f, 90 * Time.deltaTime));
    }
}
