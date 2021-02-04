using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public bool isGamePaused = false;
    public bool ResetGame = false;
    public bool PAKTSView = true;
    private bool gameOver;
    [SerializeField]
    public float PAKTSTimer;
    [SerializeField]
    public float XX, YY, ZZ;
    public GameObject pauseMenu;
    [SerializeField]
    public Player playerScript;
    public GameObject gameOverMenu;
    public GameObject optionsMenu;
    public GameObject pauseButtons;
    public GameObject gameOverButtons;
    public GameObject PAKTS;
    public GameObject GameOver;
    public AudioPlayer audioPlayerScript;

    void Start()
    {
        Time.timeScale = 0f;
        Player player = GetComponent<Player>();
        gameOver = false;
        isGamePaused = true;
        XX = (float)pauseMenu.gameObject.transform.position.y;
        YY = (float)gameOverMenu.gameObject.transform.position.y;
        ZZ = (float)gameOverMenu.transform.position.z;
    }

    void Update()
    {
        if (Input.anyKey && PAKTSView == true)
        {
            PAKTSView = false;
            isGamePaused = false;
            Time.timeScale = 1f;
            Destroy(PAKTS.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && gameOver == false)
        {
            audioPlayerScript.PlayCollectSound();
            
            if (isGamePaused)
            {
                ResumeGame();
            }
            else 
            {
                PauseGame();
            }
        }

        if(playerScript._lives <= 0 && gameOver == false)
        {
            //GameoverView = true;
            GameOver.SetActive(true);
            // gameOverMenu.SetActive(true);
            gameOver = true;
            //Time.timeScale = 0f;
            StartCoroutine(GameoverText());
        }
        if(Input.GetKeyDown(KeyCode.R) && ResetGame == true || Input.GetKeyDown(KeyCode.Space) && ResetGame == true) playAgain();
        if(gameOverMenu.gameObject.transform.position.y > (YY + 0.08f) && Time.timeScale == 0f) gameOverMenu.transform.Translate(Vector3.down * 10 * 0.01f);
        if(pauseMenu.gameObject.transform.position.y > XX && Time.timeScale == 0f) pauseMenu.transform.Translate(Vector3.down * 12 * 0.01f);

    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void PauseGame()
    {
        if (gameOver == false)
        {
            pauseMenu.SetActive(true);
            pauseMenu.gameObject.transform.position = new Vector3(pauseMenu.gameObject.transform.position.x,+12,pauseMenu.gameObject.transform.position.z);
            Time.timeScale = 0f;
            isGamePaused = true;  
        }
    }

    public void Options()
    {
       optionsMenu.gameObject.SetActive(true);
       pauseButtons.gameObject.SetActive(false);
       gameOverButtons.gameObject.SetActive(false);  
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        pauseButtons.gameObject.SetActive(true);
        gameOverButtons.gameObject.SetActive(true);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    } 

    public void playAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator GameoverText()
    {
        while(GameOver == true)
        {
            yield return new WaitForSeconds(3f); 
            gameOverMenu.SetActive(true);
            gameOverMenu.gameObject.transform.position = new Vector2(gameOverMenu.gameObject.transform.position.x,+25);
            ResetGame = true;
            if(PersistentData.data.GotNewScore == true)
            {
                audioPlayerScript.PlayHighScoreSound();
                PersistentData.data.GotNewScore = false;
            }
            Time.timeScale = 0f;
        }
    }
}