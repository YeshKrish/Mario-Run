using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife Instance;
    public AudioSource deadSound;

    bool playerDead = false;

    private void Update()
    {
        OnFalling();
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    void OnFalling()
    {
        if(transform.position.y <= -5.0f && !playerDead)
        {
            Die();
        }
    }

    void Die()
    {
        
        deadSound.Play();
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerController>().enabled = false;
        playerDead = true;
        Item.quatity = 0;
        PlayerPrefs.SetInt("RecentScene", SceneManager.GetActiveScene().buildIndex);
        Invoke("Dead", 1f);
    }

    void Dead()
    {
        GameManager.Instance.PlayerDead();
    }
}
