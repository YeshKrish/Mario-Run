using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, jumpHeight, _rb.velocity.z);
    }
}
