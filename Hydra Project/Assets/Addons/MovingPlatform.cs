using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    public bool isOnMovingPlatform = false;
    public GameObject Player;
    public bool isMovingLeft = true;
    public int element = 0;
    public float speed;
    public Material[] material;
    Renderer rend;
    public Player playerScript;
    public bool isSpawnPlatform = false;
    

    void Start()
    {
        if(!isSpawnPlatform)
        {
            element = Random.Range (0,3);
        }
        else
        {
            element = 0;
        }
        
        rend = GetComponent<Renderer>();
        rend.enabled =true;
        rend.sharedMaterial = material[element];
        playerScript = GameObject.Find("Player").GetComponent<Player>();

    }

    void Update()
    {
        if (isOnMovingPlatform)
        {
            Player.transform.SetParent(this.transform);
            if (element != playerScript.PlayerElement && playerScript.IsDamage == false)
            {
                playerScript.IsDamage = true;
                playerScript.Damage();               
            }
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
        
        if (other.gameObject.CompareTag("Player") && playerScript.isGrounded == true && playerScript.IsDamage == false)
        {
            if (element != playerScript.PlayerElement && playerScript.IsDamage == false)
            {
                playerScript.IsDamage = true;
                playerScript.Damage();
            }
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