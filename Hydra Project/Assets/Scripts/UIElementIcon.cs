using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementIcon : MonoBehaviour
{
    [SerializeField]
    public bool isElement, elementIcons, isHearts, NoHearts;
    [SerializeField]
    public float H1X, H2X, H3X, H1Y, H2Y, H3Y, HZ;
    public Player playerScript;
    public Sprite[] sprite;
    SpriteRenderer rend;
    public GameObject Heart1, Heart2, Heart3;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        if(isElement == true && elementIcons == true)
        {
            rend.enabled =true;
            rend.sprite = sprite[playerScript.PlayerElement];
        }
        else if (isElement == false && elementIcons == true)
        {
            rend.enabled =true;
            rend.sprite = sprite[playerScript.NextPlayerElement];
        }
        if(isHearts == true)
        {
            //HZ = (float)Heart2.transform.position.z;
            H1X = (float)Heart1.transform.position.x;
            H1Y = (float)Heart1.transform.position.y;
            H2X = (float)Heart2.transform.position.x;
            H2Y = (float)Heart2.transform.position.y;
            H3X = (float)Heart3.transform.position.x;
            H3Y = (float)Heart3.transform.position.y;
            set();
        }
    }


    void FixedUpdate()
    {
        if(isElement == true  && elementIcons == true) rend.sprite = sprite[playerScript.PlayerElement];
        else if (isElement == false && elementIcons == true) rend.sprite = sprite[playerScript.NextPlayerElement];
        if(isHearts == true)
        {
            if (playerScript._lives == 0) StartCoroutine(NoHeart());
            if(playerScript.IsDamage == true && NoHearts == false)
            {
                Heart1.transform.position = new Vector3(H1X + Random.Range(-0.01f, +0.02f),H1Y  + Random.Range(-0.01f, +0.02f),-4.334335f);
                Heart2.transform.position = new Vector3(H2X + Random.Range(-0.01f, +0.02f),H2Y  + Random.Range(-0.01f, +0.02f),-4.334335f);
                Heart3.transform.position = new Vector3(H3X + Random.Range(-0.01f, +0.02f),H3Y  + Random.Range(-0.01f, +0.02f),-4.334335f);
            }
            else if(playerScript.IsDamage == false && NoHearts == false) set();
        }
    
    }

    void set()
    {
        if(Heart1 != null) Heart1.transform.position = new Vector3(H1X,H1Y,-4.334335f);
        if(Heart2 != null) Heart2.transform.position = new Vector3(H2X,H2Y,-4.334335f);
        if(Heart3 != null) Heart3.transform.position = new Vector3(H3X,H3Y,-4.334335f);
    }
    public IEnumerator NoHeart()
    {
        yield return new WaitForSeconds(1f);
        NoHearts = true;
    }
}
