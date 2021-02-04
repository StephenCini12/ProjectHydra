using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    public int _lives = 3, TriggerColorChange = 0;
    [SerializeField]
    public int PlayerElement, NextPlayerElement;
    public float _Speed = 5f, _Jump = 8f;
    public float visabletimer , checkRadius , jumpTime;
    private float moveInput , jumpTimeCounter;
    private float _immune = 0f;
    public float _clipping = 0f;
    private float DashSetY;
    [SerializeField]
    public bool isOnPlatform, isGrounded, isJumping, isDashing, isDusking;
    [SerializeField]
    public bool setMovingPlatform = false, HealthSystem = true, _isright = true, canDash = true;
    [SerializeField]
    public bool giveScore = false, giveDiamond = false, giveDiamondnotsame = false, touchProjectiles = false, IsDamage = false, playerELisSameAsPlatformEL = false;
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

        if (IsDamage == true )
        {
            _immune += Time.deltaTime;
            //rend.enabled = false;
            if (rend.enabled == true && _lives > 0)
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
        if (_lives < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        if(_lives < 3)
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
            jumpTimeCounter = 0;
        }

        //Player Jump
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        // new Vector2(transform.position.x + 0.5f, transform.position.y - 0.51f), whatIsGround);
        // isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x -0.5f, transform.position.y - 0.5f),
        // new Vector2(transform.position.x + 0.5f, transform.position.y - 0.51f), whatIsGround);

        if (Input.GetKeyDown (KeyCode.W) && isGrounded && _lives > 0)
        {
            //audioPlayerScript = GetComponent<AudioPlayer>(); 
            _RB.AddForce (Vector2.up * _Jump, ForceMode2D.Impulse);
            _clipping = 0.42f;
            audioPlayerScript.PlayJumpSound();
        }
        if(isGrounded == true && Input.GetKeyDown(KeyCode.W) && _lives > 0)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            _RB.velocity = Vector2.up * _Jump;
            //_clipping = 0.15f;
            _clipping += Time.deltaTime;
            playerCollider.enabled = false;
        }

        if(Input.GetKey(KeyCode.W) && isJumping == true && _lives > 0)
        {
            if(jumpTimeCounter > 0)
            {
                _RB.velocity = Vector2.up * _Jump;
                jumpTimeCounter -= Time.deltaTime;
                _clipping += Time.deltaTime;
                //_clipping += Time.deltaTime * 1.15f;
            } 
        }
        else 
        {
            isJumping = false;
        }
        if(jumpTimeCounter <= 0 && _clipping > 0 && isDusking == false && _lives > 0 && isDashing == false && canDash == true)
        {
            _clipping = 0f;
        } 
        if(Input.GetKeyDown(KeyCode.S) && isGrounded && _clipping == 0 && _lives > 0)
        {
            _clipping = 0.365f;
            playerCollider.enabled = false;
            isDusking = true;

        }
        if (_clipping > 0)
        {
            _clipping -= Time.deltaTime;
        }
        if (_clipping <= 0)
        {
            playerCollider.enabled = true;
            _clipping = 0;
            isDusking = false;
        }
        if(Input.GetKeyDown(KeyCode.Space)  && isDashing == false && _lives > 0 && canDash == true)
        {
            isDashing = true;
            canDash = false;
            DashSetY = (float)transform.position.y;
            jumpTimeCounter = 0;
            StartCoroutine(Dash());
        }
        if (isDashing == true && _lives > 0) 
        {
            if(_isright == false) 
            {
                _RB.gravityScale = 0f;
                transform.position = new Vector2(transform.position.x,DashSetY);
                transform.Translate(Vector2.left * (_Speed*2) * Time.deltaTime);
                _clipping = 0.4f;
            }
            else 
            {
                _RB.gravityScale = 0f;
                transform.position = new Vector2(transform.position.x,DashSetY);
                transform.Translate(Vector2.right * (_Speed*2) * Time.deltaTime);
                _clipping = 0.4f;
            }
        }     
    }
    public IEnumerator Dash()
    {
        yield return new WaitForSeconds(0.25f);
        _RB.gravityScale = 2.5f;
        jumpTimeCounter = 0f;
        _clipping = 0.22f;
        canDash = false;
        isDashing = false;
        StartCoroutine(CanDash());
    }
    public IEnumerator CanDash()
    {
        yield return new WaitForSeconds(1f);
        canDash = true;
    }
    void FixedUpdate()
    {
        if (_lives > 0)
        {
            if(isDashing == false) moveInput = Input.GetAxis("Horizontal");   
            _RB.velocity = new Vector2(moveInput * _Speed, _RB.velocity.y);
            if(Input.GetKeyDown(KeyCode.A) && _isright == true)
            {
                _isright = false;
                Vector2 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            if(Input.GetKeyDown(KeyCode.D) && _isright == false)
            {
                _isright = true;
                Vector2 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
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
        if (isDusking == true)
        {
            anim.SetBool("Duck", true);
        }
        else
        {
            anim.SetBool("Duck", false);
        }
        if (isDashing == true)
        {
            anim.SetBool("Dash", true);
        }
        else
        {
            anim.SetBool("Dash", false);
        }
        if (_lives == 0)
        {
            anim.SetBool("Death", true);
        }
    }

    public void Damage()
    {
        if (_lives > 0)
        {
            _lives-= 1;
            audioPlayerScript.PlayDamageSound();
        }
    }
}
