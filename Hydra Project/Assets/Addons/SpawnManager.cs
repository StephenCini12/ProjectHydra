using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int projectileElement;
    [SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField]
    private GameObject _projectileContainer;
    private float _projectileSpeed = 1.5f;
    private bool _stopSpawning = false;
    public bool isSpawner = false;
    private int level;
    public int isLeft;
    

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        
        if (isSpawner == false)
        {
            //isLeft = 0;
            isLeft = Random.Range(0,2);
        }
    }

    // Update is called once per frame
    void Update()
    {
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

    IEnumerator SpawnRoutine()
    {
        while(_stopSpawning == false)
        {
            level = Random.Range(0,3);
            //Vector2 posToSpawn = new Vector2(0,0);

            if (isLeft == 0)
            {
                Vector2 posToSpawn = new Vector2(0,0);
                if (level == 0)
                {
                    posToSpawn = new Vector2(-10f,-1.4f);
                }
                if (level == 1)
                {
                    posToSpawn = new Vector2(-10f,0.6f);
                }
                if (level == 2)
                {
                    posToSpawn = new Vector2(-10f,2.5f);
                } 
                GameObject newProjectile = Instantiate(_projectilePrefab,posToSpawn,Quaternion.identity);
                newProjectile.transform.SetParent(_projectileContainer.transform);
            }

            else if (isLeft == 1)
            {
                Vector2 posToSpawn = new Vector2(0,0);
                if (level == 0)
                {
                    posToSpawn = new Vector2(10f,-1.4f);
                }
                if (level == 1)
                {
                    posToSpawn = new Vector2(10f,0.6f);
                }
                if (level == 2)
                {
                    posToSpawn = new Vector2(10f,2.5f);
                }
                GameObject newProjectile = Instantiate(_projectilePrefab,posToSpawn,Quaternion.identity);
                newProjectile.transform.SetParent(_projectileContainer.transform);
            }
            //GameObject newProjectile = Instantiate(_projectilePrefab,posToSpawn,Quaternion.identity);
            //newProjectile.transform.SetParent(_projectileContainer.transform);
            yield return new WaitForSeconds(1f); 
        }
    }

}
