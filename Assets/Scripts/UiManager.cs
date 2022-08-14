using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    public static UiManager instance;
    public Text highScore2;
    public Text highScore1;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public GameObject title;
    
    public Text score;
    


    void Awake()
    {
        if (instance == null) 
            instance = this;
    }


	void Start () {
        highScore1.text = "Score: " + PlayerPrefs.GetInt("Score");
    }
	

	void Update () {
		
	}

    public void GameStart()
    {
        tapText.SetActive(false);
        title.GetComponent<Animator>().Play("panel Move");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("Score").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0); 
    }
}
