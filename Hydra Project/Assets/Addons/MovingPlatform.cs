﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    public bool isOnMovingPlatform = false;
    public GameObject Player;
    public bool isMovingLeft = true;
    public int element = Random.Range (0,3);
    public float speed;
    public Material[] material;
    Renderer rend;
    

    void Start()
    {
        element = Random.Range (0,3);
        rend = GetComponent<Renderer>();
        rend.enabled =true;
        rend.sharedMaterial = material[element];


    }

    void Update()
    {
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
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x < -11.4f)
        {
            transform.position = new Vector3(11.4f,transform.position.y);
            element = Random.Range (0,3);
            rend.sharedMaterial = material[element];
        }
    }

    public void right()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if(transform.position.x > 11.4f)
        {
            transform.position = new Vector2(-11.4f,transform.position.y);
            element = Random.Range (0,3);
            rend.sharedMaterial = material[element];
        }
    }
}