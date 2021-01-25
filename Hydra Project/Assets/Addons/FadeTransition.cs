using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    [SerializeField]
    public bool TriggerFade;
    public bool IsFadingBlack;
    public Image FadeTransitionObject;
    void Start()
    {
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
        if (TriggerFade == true)
        {
            TriggerFade = false;
            fadeIn();
        }
    }

    void fadeIn()
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
