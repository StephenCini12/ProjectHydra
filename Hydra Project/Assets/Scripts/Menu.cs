using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    //[SerializeField] public bool _mouseOver;
    [SerializeField] GameObject optionsMenu;     
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject howtoplay;
    [SerializeField] GameObject Background;
    [SerializeField] GameObject Story;
    [SerializeField] public GameObject scoreMenu;
    [SerializeField] public FadeTransition FadeObject;
    public AudioPlayer audioPlayerScript;
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
        if(StartingGame >= 2f)
        {
            if(PersistentData.data.SetStoryFrame == 0) 
            {
                StartingGame = 3;
                FadeObject.IsFadingBlack = false;
                FadeObject.TriggerFade = true;
                PlayerPrefs.SetInt("SetStory", (int) 1);
                PersistentData.data.SetStoryFrame = 1;
                Story.gameObject.SetActive(true);
                StartCoroutine(StartGStory());
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Time.timeScale = 0f;
                StartingGame = 0;
            }
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
    public IEnumerator StartGStory()
    {
        yield return new WaitForSeconds(8f);
        FadeObject = GameObject.Find("FadeFrame").GetComponent<FadeTransition>();
        FadeObject.IsFadingBlack = true;
        FadeObject.TriggerFade = true;
        StartingGame = 4;
        StartCoroutine(StartG());
    }
    public void ResetData()
    {
        PersistentData.data.resetData = true;
        PersistentData.data.Highscore = 0;
        PlayerPrefs.SetInt("Highscore", (int)0);
    }

    void Update()
    {
        //SetUnitTargetPosition(UtilsClass.GetMouseWorldPositionZeroZ());
    }

}

