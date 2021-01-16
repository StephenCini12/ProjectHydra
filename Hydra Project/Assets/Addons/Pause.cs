using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public bool isGamePaused = false;
    private bool gameOver;
    public GameObject pauseMenu;
    public Player playerScript;
    public GameObject gameOverMenu;
    public GameObject optionsMenu;
    public GameObject pauseButtons;
    public GameObject gameOverButtons;

    void Start()
    {
        Time.timeScale = 1f;
        Player player = GetComponent<Player>();
        gameOver = false;
        isGamePaused = false;
    }

    void Update()
    {
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
            gameOverMenu.SetActive(true);
            gameOver = true;
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
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
    } 

    public void playAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
}