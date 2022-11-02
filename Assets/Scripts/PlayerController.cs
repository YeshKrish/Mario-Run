using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CameraContoller _camCon;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;

    public Transform groundCheck;
    public LayerMask layers;

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
        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");
        _rb.velocity = new Vector3(_hInput * speed, _rb.velocity.y, _vInput * speed);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    void Jump( )
    {
        _rb.velocity = new Vector3(_rb.velocity.x, jumpHeight, _rb.velocity.z);
        
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, layers);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }

}
