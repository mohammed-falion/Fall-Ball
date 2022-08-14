using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        
    }

	void Start () {
        gameOver = false;
        if (instance == null)
            instance = this;
    }
	

    public void on()
    {
        UiManager.instance.GameStart();
        GameObject.Find("Spawn").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
    }

    public void off()
    {
        UiManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        gameOver = true;
    }
}
