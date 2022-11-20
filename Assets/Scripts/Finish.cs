using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] AudioSource victorySound;
    [SerializeField] GameObject victoryText;
    [SerializeField] GameObject player;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] Transform playerTransform;

    float maxDistance = 0.4f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            victorySound.Play();
            victoryText.SetActive(true);
            GameManager.Instance.isGameOver = true;
            Invoke("Won", 5f);
            Invoke("StopTrigger", 0.5f);
            
        }
    }
    void StopTrigger()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance >= maxDistance)
        {
            Debug.Log(boxCollider.isTrigger);
            boxCollider.isTrigger = false;
        }
    }
    void Won()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
