using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    
    public int score;
    public int hScore;
    public static ScoreManager instance;

    void Start()
    {
        if (instance == null)
            instance = this;
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    public void IncrementScore()
    {
        score += 1;
    }

    public void DiamondScore()
    {
        score += 2;
    }


    public void StopScore()
    {

        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("Score")) 
        {
            if(score > PlayerPrefs.GetInt("Score")) 
            {
                PlayerPrefs.SetInt("Score", score);
            }
        }
        else 
        {
            PlayerPrefs.SetInt("Score", score);
        }
    }
}
