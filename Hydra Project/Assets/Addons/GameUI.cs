using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public int _lives = 3;
    public float scoreValue = 0;
    public bool HealthSystem = true;
    public Text scoreText;
    public Text highscoreText;
    // [SerializeField]
    // public bool giveDiamond = false;
    public GameObject[] hearts;
    [SerializeField]
    public ElementTimer ElementTimerScript;
    [SerializeField]
    public Player playerScript;
    [SerializeField]
    public SpawnManager SpawnManagerScript;

    
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
        if (gameObject.GetComponent<ElementTimer>() != ElementTimerScript.giveScore == true && playerScript.IsDamage == false)
        {
            //Debug.Log("cringe bro");
            scoreValue = 10 + (int)scoreValue;
            ElementTimerScript.giveScore = false;
        }
        if (gameObject.GetComponent<SpawnManager>() != playerScript.giveDiamond == true && SpawnManagerScript.Diamond == true)
        {
            //Debug.Log("cringe bro");
            scoreValue = 100 + (int)scoreValue;
            playerScript.giveDiamond = false;
        }
        if (gameObject.GetComponent<SpawnManager>() != playerScript.touchProjectiles == true && playerScript.IsDamage == false)
        {
            //Debug.Log("cringe bro");
            scoreValue = 50 + (int)scoreValue;
            playerScript.touchProjectiles = false;
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
