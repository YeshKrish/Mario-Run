using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource gameAudio;
    private void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            gameAudio.Play();
        }
    }
}
