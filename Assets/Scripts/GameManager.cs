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
        Time.timeScale = 0f;
        restartButton.SetActive(true);
        //Invoke(nameof(RestartLevel), 3f);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
       
    }
}
