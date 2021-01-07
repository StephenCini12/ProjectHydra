using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
     
    [SerializeField] GameObject optionsMenu;     
    [SerializeField] GameObject buttons;
    public int menu = 0;

    public void PlayGame ()
    {
        menu = 1;

        if(menu == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    
    }

    public void QuitGame()
    {
        Debug.Log("You Quit");
        Application.Quit();
    }

    public void Options()
    {
        menu = 3;
        if(menu == 3)
        {
            optionsMenu.SetActive(true);
            buttons.gameObject.SetActive(false);
        }
        
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        
        menu = 0;
        if(menu == 0)
        {
            buttons.gameObject.SetActive(true);
        }
    }
}

