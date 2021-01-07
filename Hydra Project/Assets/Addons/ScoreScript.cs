using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript
 : MonoBehaviour
{

    public int scoreValue = 0;
    public Text scoreText;

    
    void Start()
    {
        scoreValue = 0;
        scoreText.text = "Score: " + scoreValue;

    }

    void Update()
    {
        scoreText.text = "Score: " + scoreValue;
    }
}
