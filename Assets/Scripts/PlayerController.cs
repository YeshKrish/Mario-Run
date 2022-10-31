using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;

    float _hInput;
    float _vInput;

    Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector3(0f, 5f, 0f);
        }
        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(_hInput, 0, _vInput).normalized;
        float targetAngle = Mathf.Atan2(_hInput, _vInput) * Mathf.Rad2Deg;

        gameObject.transform.rotation = Quaternion.Euler(targetAngle, 0f, 0f); 
        controller.Move(direction * speed * Time.deltaTime);
    }
}
