using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public bool HealthSystem = true;
    public float scoreValue = 0;
    public Text scoreText;
    public GameObject[] hearts;
    public int _lives = 3;
    public ElementTimer ElementTimerScript;
    [SerializeField] GameObject optionsMenu;
    
    //public int _coinSpeed = 5;

    
    void Start()
    {
        scoreValue = 0;
        ElementTimerScript = GameObject.Find("ElementTimer").GetComponent<ElementTimer>();
        ElementTimerScript.giveScore = false;
    }

    void Update()
    {
        scoreValue += 1.5f * Time.deltaTime;
        scoreText.text = "Score: " + (int)scoreValue;
    
    if (HealthSystem)
    {
        Health();
    }

    if (ElementTimerScript.giveScore == true)
    {
        //Debug.Log("cringe bro");
        scoreValue = 10 + (int)scoreValue;
        ElementTimerScript.giveScore = false;
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

   
    public void Options()
    {
        optionsMenu.SetActive(true);
    }

     public void Resume()
    {
        optionsMenu.SetActive(false);
    }

    public void backToPause()
    {
        optionsMenu.SetActive(false);
    }   

    public void backToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }  

}
