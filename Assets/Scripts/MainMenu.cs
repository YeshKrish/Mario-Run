using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;

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
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(2);
       
    }  
    
    public void RetryGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("RecentScene"));
        Time.timeScale = 1f;
        GameManager.Instance.isGameOver = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
