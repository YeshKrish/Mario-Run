using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public AudioSource victorySound;
    public GameObject victoryText;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            victorySound.Play();
            victoryText.SetActive(true);
            GameManager.Instance.isGameOver = true; 
            Invoke("Won", 5f);
        }
    }
    void Won()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
