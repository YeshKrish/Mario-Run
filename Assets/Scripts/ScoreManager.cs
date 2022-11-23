using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI highScoreTxt;

    static int highScoreStorer = 0;

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

    // Update is called once per frame
    void Update()
    {
        highScoreTxt.text = Item.quatity.ToString();
        if(int.Parse(highScoreTxt.text) > highScoreStorer)
        {
            highScoreStorer = int.Parse(highScoreTxt.text);
            highScoreTxt.text = highScoreStorer.ToString();
        }
        else
        {
            highScoreStorer = int.Parse(highScoreTxt.text);
        }
    }
}
