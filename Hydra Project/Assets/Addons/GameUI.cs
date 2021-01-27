using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public int _lives = 3;
    [SerializeField]
    public int _pickbonus = 0;
    public float scoreValue = 0;
    [SerializeField]
    public float bonusValue = 0;
    [SerializeField]
    public bool HealthSystem = true;
    [SerializeField]
    public bool IsScore = false;
    [SerializeField]
    public bool IsBonus = false;
    public Text scoreText;
    public Text highscoreText;
    // [SerializeField]
    // public bool giveDiamond = false;
    public GameObject[] hearts;
    [SerializeField]
    private GameObject _BonusPrefab;
    [SerializeField]
    private GameObject _ScoreContainer;
    [SerializeField]
    public ElementTimer ElementTimerScript;
    [SerializeField]
    public Player playerScript;
    [SerializeField]
    public SpawnManager SpawnManagerScript;
    public AudioPlayer audioPlayerScript;

    
    void Start()
    {
        if (IsScore == true)
        {
            scoreValue = 0;
            playerScript = GameObject.Find("Player").GetComponent<Player>();
            playerScript.giveScore = false;
            scoreText.text = "" + (int)scoreValue;
        }
        if (IsBonus == true)
        {
            transform.localScale = new Vector2(0.2757833f,0.2757833f);
            transform.position = new Vector3(-7.311f,4.0194f,-4.798f);
            switch (_pickbonus)
            {
            case 1:
                scoreText.text = "+100";
                break;
            case 2:
                scoreText.text = "+250";
                break;
            case 3:
                scoreText.text = "+500";
                break;
            case 4:
                scoreText.text = "+50";
                break;
            default:
                //print ("Incorrect intelligence level.");
                break;
            }
            StartCoroutine(Delete());
            //scoreText.text = "" + (int)scoreValue;
        }
    }

    void Update()
    {
        if (IsScore == true)
        {
            highscoreText.text = "Your score: " + (int)scoreValue;
            if (playerScript._lives > 0)
            {
                scoreValue += 5f * Time.deltaTime;
            }
            scoreText.text = "" + (int)scoreValue;
            if ((ElementTimerScript.timerMax == ElementTimerScript.timeRemaining) && playerScript.giveScore == true && _lives > 0)
            {
                //Survives element without taking dmg
                Vector2 posToSpawn = new Vector3(-6.511f,4.0194f,-4.798f);
                GameObject newBonus = Instantiate(_BonusPrefab,posToSpawn,Quaternion.identity);
                newBonus.transform.SetParent(_ScoreContainer.transform);
                newBonus.GetComponent<GameUI>()._pickbonus = 1;
                scoreValue = 100 + (int)scoreValue;
                playerScript.giveScore = false;
            }
            if (gameObject.GetComponent<SpawnManager>() != playerScript.giveDiamondnotsame == true)
            {
                //Get diamond not the same element
                scoreValue = 250 + (int)scoreValue;
                audioPlayerScript.PlayCollectSound();
                Vector2 posToSpawn = new Vector3(-6.511f,4.0194f,-4.798f);
                GameObject newBonus = Instantiate(_BonusPrefab,posToSpawn,Quaternion.identity);
                newBonus.GetComponent<GameUI>()._pickbonus = 2;
                newBonus.transform.SetParent(_ScoreContainer.transform);
                playerScript.giveDiamondnotsame = false;
            }
            if (gameObject.GetComponent<SpawnManager>() != playerScript.giveDiamond == true)
            {
                //Takes diamond of the same element
                scoreValue = 500 + (int)scoreValue;
                audioPlayerScript.PlayCollectSound();
                Vector2 posToSpawn = new Vector3(-6.511f,4.0194f,-4.798f);
                GameObject newBonus = Instantiate(_BonusPrefab,posToSpawn,Quaternion.identity);
                newBonus.transform.SetParent(_ScoreContainer.transform);
                newBonus.GetComponent<GameUI>()._pickbonus = 3;
                playerScript.giveDiamond = false;
            }
            if (gameObject.GetComponent<SpawnManager>() != playerScript.touchProjectiles == true && playerScript.IsDamage == false)
            {
                //touching a current element projectile
                scoreValue = 50 + (int)scoreValue;
                Vector2 posToSpawn = new Vector3(-6.511f,4.0194f,-4.798f);
                GameObject newBonus = Instantiate(_BonusPrefab,posToSpawn,Quaternion.identity);
                newBonus.transform.SetParent(_ScoreContainer.transform);
                newBonus.GetComponent<GameUI>()._pickbonus = 4;
                playerScript.touchProjectiles = false;
            }
        }
        if (IsBonus == true)
        {
            transform.Translate(Vector2.down * 0.75f * Time.deltaTime);
        }
    }
    IEnumerator Delete()
    {
        while(IsBonus == true)
        {
            yield return new WaitForSeconds(1.25f); 
            Destroy(this.gameObject);
        }
    }

}
