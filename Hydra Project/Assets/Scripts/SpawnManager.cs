using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private int projectileElement;
    [SerializeField]
    private int diamondElement;
    public int level;
    public int isLeft;
    [SerializeField]
    public float _difficulty;
    [SerializeField]
    private float _projectileSpeed = 3f;
    [SerializeField]
    private float _projectileMaxSpeed = 6f;
    [SerializeField]
    public float _projectileRememberSpeed = 3f;
    private float _DiamondSpeed = 1.3f;
    public float visabletimer;
    private bool _stopSpawning = false;
    //private bool _onPlatform = false;
    [SerializeField]
    public bool isSpawner = false;
    [SerializeField]
    public bool Projectiles = false;
    [SerializeField]
    public bool Diamond = false;
    [SerializeField]
    public bool isWarning = false;
    [SerializeField]
    public bool isWarningShow = false;
    [SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField]
    private GameObject _projectileContainer;
    [SerializeField]
    private GameObject _DiamondPrefab;
    [SerializeField]
    private GameObject _DiamondContainer;
    [SerializeField]
    private GameObject _WarningPrefab;
    [SerializeField]
    private GameObject _WarningContainer;
    [SerializeField]
    public RuntimeAnimatorController[] runtimeAnimatorController;
    [SerializeField]
    Animator anim;
    [SerializeField]
    public SpriteRenderer rend;
    [SerializeField]
    public Player playerScript;
    // [SerializeField]
    // public GameUI GameUIScript;
    

    void Start()
    {
        if (isSpawner == true)
        {
            StartCoroutine(SpawnRoutine());
            StartCoroutine(SpawnRoutine2());
        }
        if (Projectiles == true)
        {
            _projectileSpeed = _projectileRememberSpeed;
            isLeft = Random.Range(0,2);
            projectileElement = Random.Range (0,3);
            anim = GetComponent<Animator>();
            anim.enabled =true;
            anim.runtimeAnimatorController = runtimeAnimatorController [projectileElement];
            playerScript = GameObject.Find("Player").GetComponent<Player>();
        }
        if (Diamond == true)
        {
            diamondElement = Random.Range (0,3);
            anim = GetComponent<Animator>();
            anim.enabled =true;
            anim.runtimeAnimatorController = runtimeAnimatorController [diamondElement];
            playerScript = GameObject.Find("Player").GetComponent<Player>();
            //transform.Rotate(0, 0, 45, Space.Self);
        }
        if (isWarning == true)
        {
            StartCoroutine(Delete());
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (isWarningShow == true)
        // {
        //     Vector2 posToSpawn = new Vector2(0,-10);
        //     GameObject newWarning = Instantiate(_WarningPrefab,posToSpawn,Quaternion.identity);
        //     newWarning.transform.SetParent(_WarningContainer.transform);
        //     isWarningShow = false;
        // }
        if (isSpawner == true && _difficulty > 5f)
        {
            _difficulty -= Time.deltaTime/Random.Range(30,76);
        }
        if (Projectiles == true)
        {
            // if (this._projectileSpeed <= this._projectileMaxSpeed)
            // {
            //     this._projectileSpeed += (Mathf.Abs(_difficulty)/1000000);
            // }
            if (transform.position.y <= -10 && isLeft == 0 && isSpawner == false)
            {
                level = Random.Range(0,3);
                //_WarningPrefab.GetComponent<SpawnManager>().level = this.level;
                if (level == 0)
                {
                    transform.position = new Vector2(-17f,2.5f);
                    Vector2 posToSpawn = new Vector3(-8.241f,2.4f,-1.259f);
                    GameObject newWarning = Instantiate(_WarningPrefab,posToSpawn,Quaternion.identity);
                    //newWarning.transform.SetParent(_WarningContainer.transform);
                    
                }
                if (level == 1)
                {
                    transform.position = new Vector2(-17f,0f);
                    Vector2 posToSpawn = new Vector3(-8.241f,0f,-1.259f);
                    GameObject newWarning = Instantiate(_WarningPrefab,posToSpawn,Quaternion.identity);
                }
                if (level == 2)
                {
                    transform.position = new Vector2(-17f,-2.5f);
                    Vector2 posToSpawn = new Vector3(-8.241f,-2.66f,-1.259f);
                    GameObject newWarning = Instantiate(_WarningPrefab,posToSpawn,Quaternion.identity);
                } 
            }
            if (transform.position.y <= -10 && isLeft == 1 && isSpawner == false)
            {
                level = Random.Range(0,3);
                //_WarningPrefab.GetComponent<SpawnManager>().level = this.level;
                if (level == 0)
                {
                    transform.position = new Vector2(17f,2.5f);
                    Vector2 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    Vector2 posToSpawn = new Vector3(8.241f,2.4f,-1.259f);
                    GameObject newWarning = Instantiate(_WarningPrefab,posToSpawn,Quaternion.identity);
                }
                if (level == 1)
                {
                    transform.position = new Vector2(17f,0f);
                    Vector2 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    Vector2 posToSpawn = new Vector3(8.241f,0f,-1.259f);
                    GameObject newWarning = Instantiate(_WarningPrefab,posToSpawn,Quaternion.identity);
                }
                if (level == 2)
                {
                    transform.position = new Vector2(17f,-2.5f);
                    Vector2 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    Vector2 posToSpawn = new Vector3(8.241f,-2.66f,-1.259f);
                    GameObject newWarning = Instantiate(_WarningPrefab,posToSpawn,Quaternion.identity);
                } 
            }
            if (isLeft == 0 && isSpawner == false)
            {
                transform.Translate(Vector2.right * (_projectileSpeed + (Mathf.Abs(_difficulty))/50f) * Time.deltaTime);
            }
            
            if (transform.position.x >= 10 && isSpawner == false && isLeft == 0)
            {
                Destroy(this.gameObject);
            }
            
            if (isLeft == 1 && isSpawner == false)
            {
                transform.Translate(Vector2.left * (_projectileSpeed + (Mathf.Abs(_difficulty))/50f) * Time.deltaTime);
            }
            
            if (transform.position.x <= -10 && isSpawner == false && isLeft == 1)
            {
                Destroy(this.gameObject);
            }
        }
        if (Diamond == true)
        {
            if (transform.position.y < -5f)
            {
                Destroy(this.gameObject);
            }
        }
        if (isWarning == true)
        {
            if (rend.enabled == true)
            {
                visabletimer += Time.deltaTime;
                if (visabletimer >= 0.375f)
                {
                    visabletimer = 0f;
                    rend.enabled = false;
                }
            }
            else
            {
                visabletimer += Time.deltaTime;
                if (visabletimer >= 0.375f)
                {
                    visabletimer = 0f;
                    rend.enabled = true;
                }
            }
        }
    }

    // IEnumerator SpawnRoutine()
    // {
    //     while(_stopSpawning == false)
    //     {
    //         level = Random.Range(0,3);
    //         //Vector2 posToSpawn = new Vector2(0,0);

    //         if (isLeft == 0)
    //         {
    //             Vector2 posToSpawn = new Vector2(0,0);
    //             if (level == 0)
    //             {
    //                 posToSpawn = new Vector2(-10f,-1.4f);
    //             }
    //             if (level == 1)
    //             {
    //                 posToSpawn = new Vector2(-10f,0.6f);
    //             }
    //             if (level == 2)
    //             {
    //                 posToSpawn = new Vector2(-10f,2.5f);
    //             } 
    //             GameObject newProjectile = Instantiate(_projectilePrefab,posToSpawn,Quaternion.identity);
    //             newProjectile.transform.SetParent(_projectileContainer.transform);
    //         }

    //         else if (isLeft == 1)
    //         {
    //             Vector2 posToSpawn = new Vector2(0,0);
    //             if (level == 0)
    //             {
    //                 posToSpawn = new Vector2(10f,-1.4f);
    //             }
    //             if (level == 1)
    //             {
    //                 posToSpawn = new Vector2(10f,0.6f);
    //             }
    //             if (level == 2)
    //             {
    //                 posToSpawn = new Vector2(10f,2.5f);
    //             }
    //             GameObject newProjectile = Instantiate(_projectilePrefab,posToSpawn,Quaternion.identity);
    //             newProjectile.transform.SetParent(_projectileContainer.transform);
    //         }
    //         //GameObject newProjectile = Instantiate(_projectilePrefab,posToSpawn,Quaternion.identity);
    //         //newProjectile.transform.SetParent(_projectileContainer.transform);
    //         yield return new WaitForSeconds(1f); 
    //     }
    // }
    IEnumerator SpawnRoutine()
    {
        while(_stopSpawning == false && isSpawner == true)
        {
            Vector2 posToSpawn = new Vector2(0,-10);
            GameObject newProjectile = Instantiate(_projectilePrefab,posToSpawn,Quaternion.identity);
            newProjectile.transform.SetParent(_projectileContainer.transform);
            //yield return new WaitForSeconds(2); 
            yield return new WaitForSeconds(Random.Range(5f,_difficulty)); 
        }
    }
    IEnumerator SpawnRoutine2()
    {
        while(_stopSpawning == false && isSpawner == true)
        {
            Vector2 posToSpawn2 = new Vector2(Random.Range(8.0f,-8.0f),6.25f);
            GameObject newProjectile2 = Instantiate(_DiamondPrefab,posToSpawn2,Quaternion.identity);
            newProjectile2.transform.SetParent(_DiamondContainer.transform);
            yield return new WaitForSeconds(Random.Range(25f,46f)); 
        }
    }
    IEnumerator Delete()
    {
        while(isWarning == true)
        {
            yield return new WaitForSeconds(2f); 
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D other) 
    {
        if (Projectiles == true)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerScript.GetComponent<Collider2D>());
            if (other.gameObject.CompareTag("Player") && playerScript.IsDamage == false)
            {
                if (projectileElement != playerScript.PlayerElement && playerScript.IsDamage == false)
                {
                    playerScript.IsDamage = true;
                    playerScript.Damage();
                    Destroy (this.gameObject);
                }
                if (projectileElement == playerScript.PlayerElement)
                {
                    playerScript.touchProjectiles = true;
                    Destroy (this.gameObject);
                }
                Destroy (this.gameObject);
            }
        }

        if (Diamond == true)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (diamondElement != playerScript.PlayerElement)
                {
                    playerScript.giveDiamondnotsame = true;
                    Destroy (this.gameObject);
                }
                else if (diamondElement == playerScript.PlayerElement)
                {
                    playerScript.giveDiamond = true;
                    Destroy (this.gameObject);
                }
                Destroy (this.gameObject);
            }
            // if (other.gameObject.CompareTag("Projectile"))
            // {
            //     null
            // }
        }
    }
}
