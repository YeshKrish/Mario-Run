using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform player;
    public TextMeshProUGUI levelText;

    [HideInInspector]
    public bool isGameOver = false;
    [HideInInspector]
    public int level;

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

    private void Update()
    {
        level = SceneManager.GetActiveScene().buildIndex - 1;
        levelText.text = level.ToString();


    }

    // Start is called before the first frame update 
    void Start()
    {
        CameraContoller.Instance.virtualCamera.Follow = player.transform;
    }

    public void PlayerDead()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        SceneManager.LoadScene("RetryScene");
    }

}
