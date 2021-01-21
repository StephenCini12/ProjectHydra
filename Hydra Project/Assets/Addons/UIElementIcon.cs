using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementIcon : MonoBehaviour
{
    public bool isElement;
    public Player playerScript;
    public Sprite[] sprite;
    SpriteRenderer rend;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        if(isElement == true)
        {
            rend.enabled =true;
            playerScript = GameObject.Find("Player").GetComponent<Player>();
            rend.sprite = sprite[playerScript.PlayerElement];
        }
        else
        {
            rend.enabled =true;
            playerScript = GameObject.Find("Player").GetComponent<Player>();
            rend.sprite = sprite[playerScript.NextPlayerElement];
        }
    }


    void Update()
    {
        if(isElement == true)
        {
            rend.sprite = sprite[playerScript.PlayerElement];
        }
        else
        {
            rend.sprite = sprite[playerScript.NextPlayerElement];
        }
    }
}
