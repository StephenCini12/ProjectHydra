using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public bool isGamePaused = false;
    public bool PAKTSView = true;
    public bool GameoverView = false;
    private bool gameOver;
    [SerializeField]
    public float PAKTSTimer;
    public GameObject pauseMenu;
    [SerializeField]
    public Player playerScript;
    public GameObject gameOverMenu;
    public GameObject optionsMenu;
    public GameObject pauseButtons;
    public GameObject gameOverButtons;
    public GameObject PAKTS;
    public GameObject GameOver;

    void Start()
    {
        Time.timeScale = 0f;
        Player player = GetComponent<Player>();
        gameOver = false;
        isGamePaused = true;
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
            if (isGamePaused)
            {
                ResumeGame();
            }
            else 
            {
                PauseGame();
            }
        }

        if(playerScript._lives <= 0)
        {
            Debug.Log("You DEAD");
            gameOverMenu.SetActive(true);
            gameOver = true;
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void PauseGame()
    {
        if (gameOver == false)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
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
}