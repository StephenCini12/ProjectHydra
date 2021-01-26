﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    public int _lives = 3;
    [SerializeField]
    public int PlayerElement;
    [SerializeField]
    public int NextPlayerElement;
    [SerializeField]
    public int TriggerColorChange = 0;
    public float _Speed = 5f;
    public float _Jump = 8f;
    public float visabletimer;
    private float moveInput;
    public float checkRadius;
    private float jumpTimeCounter;
    public float jumpTime;
    private float _immune = 0f;
    public float _clipping = 0f;
    [SerializeField]
    public bool _isright = true;
    [SerializeField]
    public bool setMovingPlatform = false;
    [SerializeField]
    public bool isOnPlatform;
    [SerializeField]
    public bool isGrounded;
    [SerializeField]
    private bool isJumping;
    [SerializeField]
    private bool isDashing;
    [SerializeField]
    public bool HealthSystem = true;
    [SerializeField]
    public bool giveDiamond = false;
    [SerializeField]
    public bool giveDiamondnotsame = false;
    [SerializeField]
    public bool touchProjectiles = false;
    [SerializeField]
    public bool IsDamage = false;
    public Rigidbody2D _RB;
    public Transform feetPos;    
    public LayerMask whatIsGround;
    public GameObject[] hearts;
    [SerializeField]
    public SpriteRenderer rend;
    public RuntimeAnimatorController[] runtimeAnimatorController;
    [SerializeField]
    public ElementTimer ElementTimerScript;
    public BoxCollider2D playerCollider;
    [SerializeField]
    public Animator anim;
    [SerializeField]
    public AudioPlayer audioPlayerScript;

    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerElement = 0;
        NextPlayerElement = Random.Range(1,3);
        _immune = 0f;
        _RB = GetComponent<Rigidbody2D>();
        TriggerColorChange = 0;
        rend = GetComponent<SpriteRenderer>();
        anim.enabled =true;
        ElementTimerScript.nextElement = NextPlayerElement;
        ElementTimerScript.setElement = PlayerElement;
        playerCollider = playerCollider.GetComponent<BoxCollider2D>();       
    }

    void Update()
    {
        anim.runtimeAnimatorController = runtimeAnimatorController[PlayerElement]; 
        CalculateMovement();
        FixedUpdate();
        Animations();
        
        if (HealthSystem)
        {
            Health();
        }

        if (TriggerColorChange == 1)
        {
            //ElementTimerScript = GameObject.Find("ElementTimer").GetComponent<ElementTimer>();
            ElementTimerScript.nextElement = NextPlayerElement;
            ElementTimerScript.setElement = PlayerElement;
            anim.runtimeAnimatorController = runtimeAnimatorController[PlayerElement];
        }

        if (IsDamage == true)
        {
            _immune += Time.deltaTime;
            //rend.enabled = false;
            if (rend.enabled == true)
            {
                visabletimer += Time.deltaTime;
                if (visabletimer >= 0.2f)
                {
                    visabletimer = 0f;
                    rend.enabled = false;
                }
            }
            else
            {
                visabletimer += Time.deltaTime;
                if (visabletimer >= 0.09f)
                {
                    visabletimer = 0f;
                    rend.enabled = true;
                }
            }
            if (_immune >= 2.5f)
            {
                IsDamage = false;
                _immune = 0f;
                visabletimer = 0f;
                rend.enabled = true;
            }
        }

    }

    void Health()
    {
        Player player = GetComponent<Player>();

        if (_lives < 1)
        {
            Destroy(hearts[0].gameObject);
        } 
        else if (_lives < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if(_lives <3)
        {
            Destroy(hearts[2].gameObject);
        }
    }

    void CalculateMovement()
    {

        if (transform.position.y <= -11.25f)
        {
            _lives = 0;
        }

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
        if(transform.position.y >= 3.27f)
        {
            transform.position = new Vector2(transform.position.x,3.27f);
        }

        //Player Jump
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        // new Vector2(transform.position.x + 0.5f, transform.position.y - 0.51f), whatIsGround);
        // isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x -0.5f, transform.position.y - 0.5f),
        // new Vector2(transform.position.x + 0.5f, transform.position.y - 0.51f), whatIsGround);

        if (Input.GetKeyDown (KeyCode.UpArrow) && isGrounded)
        {
            //audioPlayerScript = GetComponent<AudioPlayer>(); 
            _RB.AddForce (Vector2.up * _Jump, ForceMode2D.Impulse);
            audioPlayerScript.PlayJumpSound();
        }


        if(isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            _RB.velocity = Vector2.up * _Jump;
            _clipping = 0.15f;
            _clipping += Time.deltaTime;
            playerCollider.enabled = false;
        }

        if(Input.GetKey(KeyCode.UpArrow) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                _RB.velocity = Vector2.up * _Jump;
                jumpTimeCounter -= Time.deltaTime;
                _clipping += Time.deltaTime * 1.3f;
            } 
        }
        else 
        {
            isJumping = false;
        }
        if(jumpTimeCounter <= 0)
        {
            _clipping = 0f;
        } 
       
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
            _clipping = 0.42f;
        }

        // if(Input.GetKeyDown(KeyCode.UpArrow) && _clipping == 0)
        // {
        //     _clipping = 0.55f;
        //     playerCollider.enabled = false;
        // }
        if(Input.GetKeyDown(KeyCode.DownArrow) && isGrounded && _clipping == 0)
        {
            _clipping = 0.365f;
            playerCollider.enabled = false;
        }
        // if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        // {
        //     playerCollider.enabled = true;
        // }

        if (_clipping > 0)
        {
            _clipping -= Time.deltaTime;
        }
        if (_clipping <= 0)
        {
            playerCollider.enabled = true;
            _clipping = 0;
        }

        // if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true && isDashing == false)
        // {
        //     isDashing = true;
        //     _Speed = 25;
        //     StartCoroutine(Dash());
        // }
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == false && isDashing == false)
        {
            isDashing = true;
            _clipping = 0.35f;
            _Jump = 11;
            _Speed = 25;
            StartCoroutine(Dash());
        }
        // else if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        // {
        //     playerCollider.enabled = true;
        // }

        // //Dash left
        // if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     if (doubleTapTime > Time.time && lastKeyCode == KeyCode.LeftArrow){
        //         StartCoroutine(Dash(1f));
        //     } 
        //     else {
        //         doubleTapTime = Time.time + 0.5f;
        //     }
            
        //     lastKeyCode = KeyCode.LeftArrow;
        // }

        // //Dash right
        // if (Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     if (doubleTapTime > Time.time && lastKeyCode == KeyCode.RightArrow){
        //         StartCoroutine(Dash(1f));
        //     } 
        //     else {
        //         doubleTapTime = Time.time + 0.5f;
        //     }
            
        //     lastKeyCode = KeyCode.RightArrow;
        // }         
    }
    public IEnumerator Dash()
    {
        yield return new WaitForSeconds(0.22f);
        // if (_clipping == 0)
        // {
        //     playerCollider.enabled = false;
        // }
        _Speed = 8;
        _Jump = 5;
        isDashing = false;
    }
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");   
        _RB.velocity = new Vector2(moveInput * _Speed, _RB.velocity.y);
        if(Input.GetKeyDown(KeyCode.LeftArrow) && _isright == true)
        {
            _isright = false;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && _isright == false)
        {
            _isright = true;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void Animations()
    {
        if (moveInput == 0 && isJumping == false)
        {
            anim.SetBool("Walking", false);
        }
        else if (moveInput != 0 && isJumping == false)
        {
            anim.SetBool("Walking", true);
        }
        if (isJumping == true)
        {
            anim.SetBool("Jumping", true);
        }
        else
        {
            anim.SetBool("Jumping", false);
        }
        if (_lives == 0)
        {
            anim.SetBool("Death", true);
        }
    }

    // void OnCollisionEnter2D(Collision2D coll)
    // {
    //     setMovingPlatform = true;
    //     //Debug.Log("Hit: " + transform.name);
    //     if (coll.gameObject.tag == "Lava")
    //     {
    //         _lives = 0;
    //         //Damage();
    //     }
    // }  

    public void Damage()
    {
        _lives-= 1;
        if(_lives <= 0)
        {
            //yield return new WaitForSeconds (3);
            rend.enabled = false;
        }
    }

    // IEnumerator Dash (float direction)
    // {
    //     isDashing = true;
    //     _RB.velocity = new Vector2(_RB.velocity.x, 0f);
    //     _RB.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
    //     float gravity = _RB.gravityScale;
    //     _RB.gravityScale = 0f;
    //     yield return new WaitForSeconds(0.4f);
    //     isDashing = false;
    //     _RB.gravityScale = gravity;
    //}
    // IEnumerator Jumping()
    // {
    //     while(Jumping == true)
    //     {
    //         yield return new WaitForSeconds(5f); 
    //     }
    // }
}
