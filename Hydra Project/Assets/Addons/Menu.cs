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
        FadeObject = GameObject.Find("FadeFrame").GetComponent<FadeTransition>();
        FadeObject.IsFadingBlack = true;
        FadeObject.TriggerFade = true;
        StartingGame = 1;
        StartCoroutine(Start());
    }
    public void Startgame ()
    {
        if(StartingGame == 1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1f;
        }
    }

    public void howTo ()
    {
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
    public IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        Startgame();
    }
}

