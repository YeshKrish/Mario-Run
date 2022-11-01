using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

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
    }

    public void PlayerDead()
    {
        Invoke(nameof(RestartLevel), 3f);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
       
    }
}
