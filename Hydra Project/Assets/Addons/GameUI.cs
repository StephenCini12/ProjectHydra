﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public bool HealthSystem = true;
    public float scoreValue = 0;
    public Text scoreText;
    public Text highscoreText;
    public GameObject[] hearts;
    public int _lives = 3;
    [SerializeField]
    public ElementTimer ElementTimerScript;
    [SerializeField]
    public Player playerScript;

    
    void Start()
    {
        //Time.timeScale = 1f;
        scoreValue = 0;
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        ElementTimerScript.giveScore = false;
    }

    void Update()
    {
        highscoreText.text = "Your score: " + (int)scoreValue;
        scoreValue += 3f * Time.deltaTime;
        scoreText.text = "Score: " + (int)scoreValue;
        if (gameObject.GetComponent<ElementTimer>() != ElementTimerScript.giveScore == true)
        {
            //Debug.Log("cringe bro");
            scoreValue = 10 + (int)scoreValue;
            ElementTimerScript.giveScore = false;
        }
        if (ElementTimerScript.giveDiamond == true)
        {
            //Debug.Log("cringe bro");
            scoreValue = 100 + (int)scoreValue;
            ElementTimerScript.giveDiamond = false;
        }
    }

    // void Health()
    // {
    //     Player player = GetComponent<Player>();

    //     if (_lives < 1)
    //     {
    //         Destroy(hearts[0].gameObject);
    //     } else if (_lives < 2)
    //     {
    //         Destroy(hearts[1].gameObject);
    //     }else if(_lives <3)
    //     {
    //         Destroy(hearts[2].gameObject);
    //     }
    // }


}
