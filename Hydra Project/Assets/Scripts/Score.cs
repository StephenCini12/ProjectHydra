using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float Setscore;
    public Text scoreText;
    void Start()
    {
        //PersistentData.data.Highscore = PlayerPrefs.GetInt("Highscore");
        Setscore = PersistentData.data.Highscore;
        scoreText.text = ""+(int)Setscore;
    }

    void Update()
    {
        if(PersistentData.data.resetData == true)
        {
            Setscore = 0;
            scoreText.text = ""+(int)Setscore;
            PersistentData.data.resetData = false;
        }
    }
}
