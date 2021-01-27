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
    public AudioPlayer audioPlayerScript;

    
    void Start()
    {
        //Time.timeScale = 1f;
        scoreValue = 0;
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        ElementTimerScript.giveScore = false;
        scoreText.text = "" + (int)scoreValue;
    }

    void Update()
    {
        highscoreText.text = "Your score: " + (int)scoreValue;
        if (playerScript._lives > 0)
        {
            scoreValue += 5f * Time.deltaTime;
        }
        scoreText.text = "" + (int)scoreValue;
        if (gameObject.GetComponent<ElementTimer>() != ElementTimerScript.giveScore == true && playerScript.IsDamage == false)
        {
            //Survives element without taking dmg
            scoreValue = 100 + (int)scoreValue;
            ElementTimerScript.giveScore = false;
        }
        if (gameObject.GetComponent<SpawnManager>() != playerScript.giveDiamondnotsame == true)
        {
            //Get diamond not the same element
            scoreValue = 250 + (int)scoreValue;
            audioPlayerScript.PlayCollectSound();
            playerScript.giveDiamondnotsame = false;
        }
        if (gameObject.GetComponent<SpawnManager>() != playerScript.giveDiamond == true)
        {
            //Takes diamond of the same element
            scoreValue = 500 + (int)scoreValue;
            audioPlayerScript.PlayCollectSound();
            playerScript.giveDiamond = false;
        }
        if (gameObject.GetComponent<SpawnManager>() != playerScript.touchProjectiles == true && playerScript.IsDamage == false)
        {
            //touching a current element projectile
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
