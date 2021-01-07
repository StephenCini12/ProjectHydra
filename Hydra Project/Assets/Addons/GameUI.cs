using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public bool HealthSystem = true;
    public int scoreValue = 0;
    public Text scoreText;
    public GameObject[] hearts;
    public int _lives = 3;
    public int _coinSpeed = 5;

    
    void Start()
    {
        scoreValue = 0;
        scoreText.text = "Score: " + scoreValue;

    }

    void Update()
    {
        scoreText.text = "Score: " + scoreValue;

     if (HealthSystem)
        {
            Health();
        }
    }

    void Health()
    {
        Player player = GetComponent<Player>();

        if (_lives < 1)
        {
            Destroy(hearts[0].gameObject);
        } else if (_lives < 2)
        {
            Destroy(hearts[1].gameObject);
        }else if(_lives <3)
        {
            Destroy(hearts[2].gameObject);
        }
    }
}
