using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject restartButton;


    public static GameManager Instance;
    public Transform player;

    [HideInInspector]
    public bool isGameOver = false;

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

    // Start is called before the first frame update 
    void Start()
    {
        CameraContoller.Instance.virtualCamera.Follow = player.transform;
        restartButton.SetActive(false);
    }

    public void PlayerDead()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        restartButton.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        isGameOver = false;
       
    }
}
