using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    public bool isPlatformManager = false, isOnMovingPlatform = false, isSpawnPlatform = false, canMove = false, HoppedOn = false;
    [SerializeField]
    public bool isMovingLeft = true;
    [SerializeField]
    public int element = 0;
    [SerializeField]
    private int _random = 0;
    [SerializeField]
    public int helppedelement = 1;
    [SerializeField]
    public int _level;
    [SerializeField]
    public float SetY, speed, maxspeed;
    [SerializeField]
    public float _difficulty;
    public GameObject Player;
    public Sprite[] sprite;
    SpriteRenderer rend;
    public Player playerScript;
    public SpawnManager SpawnManagerScript;
    // [SerializeField]
    // public bool helpedSpawn = false;
    

    void Start()
    {
        _random = Random.Range(0,7);
        this.SetY = (float)this.transform.position.y;
        if (isSpawnPlatform == false &&_random == 6) isSpawnPlatform = true;
        if(!isSpawnPlatform) element = Random.Range(0,3);
        else element = 0;

        if(_level == 1) speed = 1.15f;
        if(_level == 2) speed = 1.65f;
        if(_level == 3) speed = 2.05f;

        this.maxspeed = this.speed*2.2f;
        rend = GetComponent<SpriteRenderer>();
        rend.enabled =true;
        rend.sprite = sprite[element];
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        //this.speed = this.maxspeed;
        // StartCoroutine(Helpping());
    }

    void Update()
    {
        //this.speed += Mathf.Abs(SpawnManagerScript._difficulty)/100000;

        if (isOnMovingPlatform)
        {
            Player.transform.SetParent(this.transform);
            if (element != playerScript.PlayerElement && playerScript.IsDamage == false)
            {
                playerScript.IsDamage = true;
                playerScript.Damage();        
            }
            if (playerScript.PlayerElement == this.element) playerScript.playerELisSameAsPlatformEL = true;
            else playerScript.playerELisSameAsPlatformEL = false;
            //if (playerScript._clipping <= 0) playerScript.canDash = true;
        }
        else Player.transform.SetParent(null);

        if (isMovingLeft) left ();
        else right ();


        // if(helpedSpawn == true)
        // {
        //     helppedelement = Random.Range(1,5);
        //     helpedSpawn = false;
        // }
    }

    void FixedUpdate()
    {
        if(this.speed <= this.maxspeed) this.speed += SpawnManagerScript._difficulty / 500000;
    }
    

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnMovingPlatform = true;
            if (HoppedOn == false)
            {
                StartCoroutine(Hopped());
                HoppedOn = true;
            }
        }
        
        if (other.gameObject.CompareTag("Player") && playerScript.isGrounded == true && playerScript.IsDamage == false)
        {
            if (element != playerScript.PlayerElement && playerScript.IsDamage == false && playerScript._clipping == 0)
            {
                playerScript.IsDamage = true;
                playerScript.Damage();
            }
        }
        if (other.gameObject.CompareTag("Diamond"))
        {
            //tag.transform.stop
            
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnMovingPlatform = false;
            playerScript.playerELisSameAsPlatformEL = false;
        }
    }

   //Teleport
    public void left()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x < -13.125f)
        {
            helppedelement = (Random.Range(0,5) + Random.Range(0,2)) + 1;
            if (helppedelement >= 4)
            {
                element = playerScript.NextPlayerElement;
                rend.sprite = sprite[element];
            }
            else if(helppedelement <= 3)
            {
                element = Random.Range (0,3);
                rend.sprite = sprite[element];
            }
            transform.position = new Vector3(13.125f,transform.position.y);
            // rend.sharedMaterial = material[element];
        }
    }

    public void right()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if(transform.position.x > 13.125f)
        {
            helppedelement = Random.Range(0,5) + Random.Range(0,2);
            if (helppedelement >= 4)
            {
                element = playerScript.NextPlayerElement;
                rend.sprite = sprite[element];
            }
            else if(helppedelement <= 3)
            {
                element = Random.Range (0,3);
                rend.sprite = sprite[element];
            }
            transform.position = new Vector2(-13.125f,transform.position.y);
        
        }
    }
    
    public IEnumerator Hopped()
    {
        this.transform.position = new Vector2(transform.position.x,(transform.position.y - 0.025f));
        yield return new WaitForSeconds (0.1f);
        while(SetY != (float)transform.position.y)
        {
            this.transform.position = new Vector2(transform.position.x, this.SetY);
            HoppedOn = false;
        }
    }

}