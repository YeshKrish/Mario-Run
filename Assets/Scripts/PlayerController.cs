using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    [SerializeField] Item item;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource coinSound;
    public float jumpButtonGracePeriod;
    public Transform groundCheck;
    public LayerMask layers;

    [SerializeField] Animator playerAnimation;

    CameraContoller _camCon;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;


    float? lastGroundedTime;
    float? jumpButtonPressedTime;
    float _hInput;
    float _vInput;

    Rigidbody _rb;

    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;
    int isBackWalkingHash;

    // Start is called before the first frame update
    void Start()
    {
        //Item.quatity = 0;
        coinText.text = Item.quatity.ToString();
        _rb = GetComponent<Rigidbody>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isRunning");
        isBackWalkingHash = Animator.StringToHash("isBackWalk");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = playerAnimation.GetBool(isRunningHash);
        bool isJumping = playerAnimation.GetBool(isRunningHash);
        bool isWalking = playerAnimation.GetBool(isWalkingHash);
        bool isBackWalking = playerAnimation.GetBool(isBackWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");
        bool backPressed = Input.GetKey("s");

        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");

        if (forwardPressed && !isWalking)
        {
            playerAnimation.SetBool("isWalking", true);
        }
        else if (!forwardPressed && isWalking)
        {
            playerAnimation.SetBool("isWalking", false);
        } 
        if ((forwardPressed && runPressed) && !isRunning )
        {
            speed = 10f;
            playerAnimation.SetBool("isRunning", true);
        }
        else if ((!forwardPressed || !runPressed) && isRunning)
        {
            playerAnimation.SetBool("isRunning", false);
            speed = 5f;
        }
        if(backPressed && !isBackWalking)
        {
            playerAnimation.SetBool("isBackWalk", true);
        }
        else if(isBackWalking && !backPressed)
        {
            playerAnimation.SetBool("isBackWalk", false);
        }


        if (IsGrounded())
        {
            lastGroundedTime = Time.time;
        }

        if (jumpPressed)
        {
            jumpButtonPressedTime = Time.time;
        }

        _rb.velocity = new Vector3(_hInput * speed, _rb.velocity.y, _vInput * speed);
        if ((Time.time - lastGroundedTime <= jumpButtonGracePeriod))
        {
            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                if (!isJumping)
                {
                    playerAnimation.SetBool("isJumping", true);
                    jumpButtonPressedTime = null;
                    lastGroundedTime = null;
                    Jump();

                }
            }

        }
        else if (!jumpPressed)
        {
            playerAnimation.SetBool("isJumping", false);
        }
    }

    void Jump()
    {
        Debug.Log(jumpHeight);
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
            jumpHeight = 10f;
            Jump();
        }
        else
        {
            jumpHeight = 7f;
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
