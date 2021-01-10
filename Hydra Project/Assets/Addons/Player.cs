using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int _lives = 3;
    public GameObject[] hearts;
    public bool HealthSystem = true;
    public int PlayerElement = 0;
    public int NextPlayerElement = 0;
    public Renderer rend;
    public Material[] material;
    public ElementTimer ElementTimerScript;
    public int TriggerColorChange = 0;
    public bool setMovingPlatform = false;
    public BoxCollider2D playerCollider;


    void Start()
    {
        PlayerElement = 1;
        NextPlayerElement = 1;
        _RB = GetComponent<Rigidbody2D>();
        TriggerColorChange = 0;
        rend = GetComponent<Renderer>();
        rend.enabled =true;
        ElementTimerScript = GameObject.Find("ElementTimer").GetComponent<ElementTimer>();

        playerCollider = playerCollider.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        rend.sharedMaterial = material[PlayerElement]; 
        CalculateMovement();
        FixedUpdate();
        if (HealthSystem)
        {
            Health();
        }

        if (TriggerColorChange == 1)
        {
            ElementTimerScript.nextElement = NextPlayerElement;
            ElementTimerScript.setElement = PlayerElement;
            rend.sharedMaterial = material[PlayerElement];
        }
    }
    void Health()
    {
        Player player = GetComponent<Player>();

        if (_lives < 1)
        {
            Destroy(hearts[0].gameObject);
        } else if (_lives < 2)
        {
            Destroy(hearts[1].gameObject);
        }else if(_lives <3)
        {
            Destroy(hearts[2].gameObject);
        }

        if (_lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
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


        //if(Input.GetKey(KeyCode.DownArrow) && isGrounded)
        //{
            //Debug.Log("Go Down");
            //playerCollider.isTrigger = true;
        //}
        //if(Input.GetKeyUp(KeyCode.DownArrow))
        //{
            //playerCollider.isTrigger = false;
        //}        
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");   
        _RB.velocity = new Vector2(moveInput * _Speed, _RB.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        setMovingPlatform = true;
        //Debug.Log("Hit: " + transform.name);
        if (coll.gameObject.tag == "Lava")
        {
           Damage();
        }
    }  

    public void Damage()
    {
        _lives-= 1;
        if(_lives <= 0)
        {
            Debug.Log("You died...GAME OVER");
            //yield return new WaitForSeconds (3);
            rend.enabled = false;
        }
    }
}