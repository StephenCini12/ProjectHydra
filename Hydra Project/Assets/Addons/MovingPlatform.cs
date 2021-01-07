using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    public bool isOnMovingPlatform = false;
    public GameObject Player;
    public bool isMovingLeft = true;
    int element;


    public Material[] material;
    Renderer rend;
    


    void Start()
    {
        element=0;
        rend = GetComponent<Renderer>();
        rend.enabled =true;
        rend.sharedMaterial = material[element];

        element = Random.Range (0,3);

    }

    //public void NextColor()
    //{
        //if(element<2)
        //{
            //element++;
        //}
        //else
        //{
            //element=0;
        //}
    //}


    void Update()
    {

        rend.sharedMaterial = material[element];

        if (isOnMovingPlatform)
        {
            Player.transform.SetParent(this.transform);
        }
        else
        {
            Player.transform.SetParent(null);
        }

       if (isMovingLeft)
        {
            left ();
        }

        else 
        {
            right ();
        }

    }



    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnMovingPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnMovingPlatform = false;
        }
    }

   //Teleport
    public void left()
    {
        transform.Translate(Vector2.left * 1 * Time.deltaTime);

        if(transform.position.x < -11.25f)
        {
            transform.position = new Vector3(11.25f,transform.position.y);
            element = Random.Range (0,3);
        }
    }

    public void right()
    {
        transform.Translate(Vector2.right * 1 * Time.deltaTime);

        if(transform.position.x > 11.25f)
        {
            transform.position = new Vector2(-11.25f,transform.position.y);
            element = Random.Range (0,3);
        }
    }
}