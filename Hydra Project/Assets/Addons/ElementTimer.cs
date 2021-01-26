using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementTimer : MonoBehaviour
{
    [SerializeField]
    public int nextElement = 0;
    [SerializeField]
    public int setElement = 1;
    [SerializeField]
    private float timeRemaining = 5f;
    [SerializeField]
    public float timerMax = 5f;
    [SerializeField]
    public bool holdElement = true;
    [SerializeField]
    public bool isSlider = true;
    [SerializeField]
    public bool giveScore = false;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    Image rend;
    [SerializeField]
    public Color[] color;
    public Player playerScript;
    [SerializeField]
    public SpawnManager SpawnManagerScript;


    void Start()
    {
        rend = GetComponent<Image>();
        //rend.enabled =true;
        if (isSlider)
        {
            timeRemaining = SpawnManagerScript._difficulty/5;
            rend.enabled = true;
            playerScript = GameObject.Find("Player").GetComponent<Player>();
            rend.color = color[playerScript.PlayerElement];
        }
        else
        {
            rend.enabled = true;
            playerScript = GameObject.Find("Player").GetComponent<Player>();
            rend.color = color[playerScript.NextPlayerElement];
        }
    }

    void Update()
    {
        if (isSlider)
        {
            timerMax = SpawnManagerScript._difficulty/5;
            // if (timeRemaining <= 0)
            // {

            // }
            ColorChange();
            SliderTimer();
        }
        else
        {
            nextElement = playerScript.NextPlayerElement;
            setElement = playerScript.PlayerElement;
            BackElement();
        }
    }
    public void ColorChange()
    {
        if (playerScript.TriggerColorChange == 1)
        {
            playerScript.TriggerColorChange = 0;
        }
    }   
    
    public void SliderTimer()
    {
        slider.value = CalculateSliderValue();

            if(timeRemaining <= 0)
            {
                timeRemaining = timerMax;
                playerScript.PlayerElement = playerScript.NextPlayerElement;
                playerScript.NextPlayerElement = playerScript.NextPlayerElement + Random.Range(-1 , +2);
                if (playerScript.NextPlayerElement <= -1)
                {
                    playerScript.NextPlayerElement = 2;
                }
                if (playerScript.NextPlayerElement == playerScript.PlayerElement)
                {
                    playerScript.NextPlayerElement = playerScript.NextPlayerElement + 1;
                }
                if (playerScript.NextPlayerElement >= 3)
                {
                    playerScript.NextPlayerElement = 0;
                }
                if (playerScript.IsDamage == false)
                {
                    giveScore = true;
                    //Debug.Log("lol you got points");
                }
                rend.color = color[playerScript.PlayerElement];
                
                playerScript.TriggerColorChange = 1;
                //Debug.Log("Next Element " + playerElement);
            }
            else if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            // else if(timeRemaining == timerMax)
            // {
            //     //playerScript.NextPlayerElement = Random.Range(0,3);
            //     //rend.color = color[nextElement];
            // }
    }
    public float CalculateSliderValue()
    {
        return(timeRemaining / timerMax);
    }
    public void BackElement()
    {
        if (playerScript.TriggerColorChange == 1)
        {
            rend.color = color[playerScript.NextPlayerElement];
        }
    }
    // IEnumerator Hold()
    // {
    //     while(holdElement == false)
    //     {
    //         yield return new WaitForSeconds(1f);
    //         holdElement = true;
    //     }
    // }
    // IEnumerator Timer()
    // {
    //     yield return new WaitForSeconds (5f);
    // }

}
