using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _Speed = 5f;
    public float _Jump = 8f;
    public Rigidbody2D _RB;
    public bool isOnPlatform;
    private float moveInput;
    public bool isGrounded;
    public Transform feetPos;    
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private int _lives = 3;

    void Start()
    {
            _RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       CalculateMovement();
       FixedUpdate();
    }

    void CalculateMovement()
    {
        //Player Collissions      
        //if the player's y position is smaller or equal to -3.8f
            if(transform.position.x <= -8.5f)
            {
                //stop the player from going lower then -3.8f
                transform.position = new Vector2(-8.5f,transform.position.y);
            }

            else if(transform.position.x >= 8.5f)
            {
                transform.position = new Vector2(8.5f,transform.position.y);
            }

        //Player Jump
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x -0.5f, transform.position.y - 0.5f),
        new Vector2(transform.position.x + 0.5f, transform.position.y - 0.51f), whatIsGround);

       if (Input.GetKeyDown (KeyCode.UpArrow) && isGrounded)
       {
          _RB.AddForce (Vector2.up * _Jump, ForceMode2D.Impulse);
       }


       if(isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
       {
           isJumping = true;
           jumpTimeCounter = jumpTime;
           _RB.velocity = Vector2.up * _Jump;
       }

       if(Input.GetKey(KeyCode.UpArrow) && isJumping == true)
       {
           if(jumpTimeCounter > 0)
            {
                _RB.velocity = Vector2.up * _Jump;
                jumpTimeCounter -= Time.deltaTime;
            } 
        }

           else 
           {
               isJumping = false;
           }
       
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
        }
    }

    void FixedUpdate()
    {
        //Player Move
        //GetAxisRaw" to make it snappy
        moveInput = Input.GetAxis("Horizontal");   
        _RB.velocity = new Vector2(moveInput * _Speed, _RB.velocity.y);
        
    }
}