using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;     
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject howtoplay;
    [SerializeField] GameObject Background;
    [SerializeField] public GameObject scoreMenu;
    [SerializeField] public FadeTransition FadeObject;
    int StartingGame = 0;

    public void PlayGame ()
    {
        //Debug.Log("bruh it me");
        if (StartingGame == 1f)
        {
            FadeObject = GameObject.Find("FadeFrame").GetComponent<FadeTransition>();
            FadeObject.IsFadingBlack = true;
            FadeObject.TriggerFade = true;
            StartingGame = 2;
            StartCoroutine(StartG());
        }
    }
    public void Startgame ()
    {
        //Debug.Log("bruh it me");
        if(StartingGame == 2f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 0f;
            StartingGame = 0;
        }
    }

    public void howTo ()
    {
        StartingGame = 1;
        Background.gameObject.SetActive(false);
        buttons.gameObject.SetActive(false);
        howtoplay.gameObject.SetActive(true);
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
    public IEnumerator StartG()
    {
        yield return new WaitForSeconds(1f);
        Startgame();
    }
}

