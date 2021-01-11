using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementTimer : MonoBehaviour
{
    public bool isSlider = true;
    private float timeRemaining = 5f;
    [SerializeField]
    private const float timerMax = 5f;
    public Slider slider;
    public int nextElement;
    public int setElement;
    Image rend;
    public Color[] color;
    public Player playerScript;


    void Start()
    {
        rend = GetComponent<Image>();
        //rend.enabled =true;
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        if (isSlider)
        {
            playerScript.PlayerElement = 0;
            playerScript.NextPlayerElement = 0;
            rend.color = color[setElement];
        }
        else
        {
            playerScript.PlayerElement = 0;
            playerScript.NextPlayerElement = 1;
            rend.color = color[playerScript.NextPlayerElement];
        }
    }

    void Update()
    {
        if (isSlider)
        {
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
            rend.color = color[setElement];
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
                playerScript.NextPlayerElement = Random.Range(0,3);
                playerScript.TriggerColorChange = 1;
                //Debug.Log("Next Element " + playerElement);
            }
            else if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else if(timeRemaining == timerMax)
            {
                //playerScript.NextPlayerElement = Random.Range(0,3);
                //rend.color = color[nextElement];
            }
        }
    private float CalculateSliderValue()
    {
        return(timeRemaining / timerMax);
    }
    public void BackElement()
    {
        if (playerScript.TriggerColorChange == 1)
        {
            rend.color = color[nextElement];
        }
    }
}
