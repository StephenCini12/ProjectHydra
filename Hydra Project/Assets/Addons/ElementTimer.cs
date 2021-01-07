using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementTimer : MonoBehaviour
{
    private float timeRemaining;
    private const float timerMax = 5f;
    public Slider slider;
    int element;  
    Renderer m_Renderer;
    public SpriteRenderer spriteRenderer;

    public Material[] material;
    Renderer rend;
    public Image _color;


    void Start()
    {
        element=0;
        rend = GetComponent<Renderer>();
        rend.enabled =true;
        rend.sharedMaterial = material[element];

        element = Random.Range (0,3);

    }

    void Update()
    {
       SliderTimer();  

       _color.GetComponent<Image>().color = new Color32(145,214,215,100);    
    }

    void SliderTimer()
       {
            slider.value = CalculateSliderValue();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                timeRemaining = timerMax;
            }

            if(timeRemaining <= 0)
            {
                timeRemaining = timerMax;
            }

            else if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            if(spriteRenderer != null)
            {
                Color newColor = new Color 
                (Random.value,
                Random.value,
                Random.value);

                spriteRenderer.color = newColor;
            }
        }


    float CalculateSliderValue()
    {
        return(timeRemaining / timerMax);
    }

}
