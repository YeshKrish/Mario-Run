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

    [SerializeField] private float m_turnSpeed = 200;

    [SerializeField] float speed = 5f;

    [SerializeField] float jumpHeight = 5f;

    public float jumpButtonGracePeriod;
    public Transform groundCheck;
    public LayerMask layers;

    [SerializeField] Animator playerAnimation;

    CameraContoller _camCon;

    private readonly float m_interpolation = 10;

    float? lastGroundedTime;
    float? jumpButtonPressedTime;
    float _hInput;
    float _vInput;

    Rigidbody _rb;

    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;

    // Start is called before the first frame update
    void Start()
    {
        //Item.quatity = 0;
        coinText.text = Item.quatity.ToString();
        _rb = GetComponent<Rigidbody>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumping = playerAnimation.GetBool(isJumpingHash);
        bool isWalking = playerAnimation.GetBool(isWalkingHash);
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

        if (IsGrounded())
        {
            lastGroundedTime = Time.time;
        }

        if (jumpPressed)
        {
            jumpButtonPressedTime = Time.time;
        }

        _rb.velocity = new Vector3(_hInput * speed, _rb.velocity.y, _vInput * speed);

        //Ground Check - if not jumping make the player jump and again set the jumpPressed time to null to do a continuous jump
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
        //Power - If jumped on enemy head jump height is increased
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
                HighScoreChecker();
                coinText.text = Item.quatity.ToString();
                Debug.Log("PickedUp Object: " + hitObject.objectName);
                other.gameObject.SetActive(false);
            }
        }
    }

    void HighScoreChecker()
    {
        //Need to revert highscore if player is dead
        if(Item.quatity > PlayerPrefs.GetInt("HighScore", 0) && PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Item.quatity);
        }
    }

}
