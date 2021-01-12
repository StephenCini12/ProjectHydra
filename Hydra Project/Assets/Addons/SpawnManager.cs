﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int projectileElement;
    [SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField]
    private GameObject _projectileContainer;
    private float _projectileSpeed = 3f;
    private bool _stopSpawning = false;
    public bool isSpawner = false;
    private int level;
    public int isLeft;
    public Material[] material;
    Renderer rend;
    [SerializeField]
    private Player playerScript = GameObject.Find("Player").GetComponent<Player>();
    

    void Start()
    {
        if (isSpawner == true)
        {
            StartCoroutine(SpawnRoutine());
        }
        else 
        {
            isLeft = Random.Range(0,2);
            projectileElement = Random.Range (0,3);
            rend = GetComponent<Renderer>();
            rend.enabled =true;
            rend.sharedMaterial = material[projectileElement];
            playerScript = GameObject.Find("Player").GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -5 && isLeft == 0 && isSpawner == false)
        {
            level = Random.Range(0,3);
            if (level == 0)
            {
                transform.position = new Vector2(-10f,-1.4f);
            }
            if (level == 1)
            {
                transform.position = new Vector2(-10f,0.6f);
            }
            if (level == 2)
            {
                transform.position = new Vector2(-10f,2.5f);
            } 
        }
        if (transform.position.y <= -5 && isLeft == 1 && isSpawner == false)
        {
            level = Random.Range(0,3);
            if (level == 0)
            {
                transform.position = new Vector2(10f,-1.4f);
            }
            if (level == 1)
            {
                transform.position = new Vector2(10f,0.6f);
            }
            if (level == 2)
            {
                transform.position = new Vector2(10f,2.5f);
            } 
        }
        if (isLeft == 0 && isSpawner == false)
        {
            transform.Translate(Vector2.right * _projectileSpeed * Time.deltaTime);
        }
        
        if (transform.position.x >= 10 && isSpawner == false && isLeft == 0)
        {
            Destroy(this.gameObject);
        }
        
        if (isLeft == 1 && isSpawner == false)
        {
            transform.Translate(Vector2.left * _projectileSpeed * Time.deltaTime);
        }
        
        if (transform.position.x <= -10 && isSpawner == false && isLeft == 1)
        {
            Destroy(this.gameObject);
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
            Vector2 posToSpawn = new Vector2(0,-5);
            GameObject newProjectile = Instantiate(_projectilePrefab,posToSpawn,Quaternion.identity);
            newProjectile.transform.SetParent(_projectileContainer.transform);
            yield return new WaitForSeconds(5f); 
        }
    }
    public void OnCollisionEnter2D(Collision2D other) 
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerScript.GetComponent<Collider2D>());
        if (other.gameObject.CompareTag("Player") && playerScript.IsDamage == false)
        {
            if (projectileElement != playerScript.PlayerElement && playerScript.IsDamage == false)
            {
                playerScript.IsDamage = true;
                playerScript.Damage();
            }
        }
        Destroy (this.gameObject);
    }
}
