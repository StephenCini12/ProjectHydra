using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
     
    [SerializeField] GameObject optionsMenu;     
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject howToPlay;
    public GameObject scoreMenu;

    public void PlayGame ()
    {
        howToPlay.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void howTo ()
    {
        howToPlay.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("You Quit");
        Application.Quit();
    }

    public void Volume()
    {
        optionsMenu.SetActive(true);
        buttons.gameObject.SetActive(false); 
    }

    public void Score()
    {
        scoreMenu.SetActive(true);
        buttons.gameObject.SetActive(false); 
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        scoreMenu.SetActive(false);
        buttons.gameObject.SetActive(true);
    }
}

