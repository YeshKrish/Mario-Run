using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    public Item item;
    public AudioSource jumpSound;
    public AudioSource coinSound;


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
        //Item.quatity = 0;
        coinText.text = Item.quatity.ToString();
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
        jumpSound.Play(); 
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
            Jump();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUps"))
        {
            coinSound.Play();
            Item hitObject = other.gameObject.GetComponent<Consumables>().item;
            if(hitObject != null)
            {

                Item.quatity = Item.quatity +1;
                Debug.Log(Item.quatity);
                coinText.text = Item.quatity.ToString();
                Debug.Log("PickedUp Object: " + hitObject.objectName);
                other.gameObject.SetActive(false);
            }
        }
    }


}
