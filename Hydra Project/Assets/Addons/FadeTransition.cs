using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    [SerializeField]
    public bool TriggerFade = true;
    [SerializeField]
    public bool IsFadingBlack = false;
    [SerializeField]
    public Image FadeTransitionObject;
    void Start()
    {
        Time.timeScale = 1f;
        TriggerFade = true;
        IsFadingBlack = false;
        FadeTransitionObject.enabled = true;

        if (IsFadingBlack == true)
        {
            FadeTransitionObject.canvasRenderer.SetAlpha(0.0f);
        }
        else
        {
            FadeTransitionObject.canvasRenderer.SetAlpha(1.0f);
        }
        fadeIn();
    }

    void Update()
    {
        if (TriggerFade == true && IsFadingBlack == false)
        {
            fadeIn();
            IsFadingBlack = true;
            TriggerFade = false;
        }
        if (TriggerFade == true && IsFadingBlack == true)
        {
            fadeIn();
            IsFadingBlack = false;
            TriggerFade = false;
        }
    }

    public void fadeIn()
    {
        if (IsFadingBlack == true)
        {
            FadeTransitionObject.CrossFadeAlpha(1,0.95f,false);
        }
        else
        {
            FadeTransitionObject.CrossFadeAlpha(0,0.95f,false);
        }
    }
}
