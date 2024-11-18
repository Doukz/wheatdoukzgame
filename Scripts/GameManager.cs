using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemyOne;
    public GameObject cloud;
    public GameObject powerup;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public AudioClip powerUp;
    public AudioClip powerDown;
    
    public AudioClip shieldUp;
    public AudioClip shieldDown;

    public int cloudSpeed;

    private bool isPlayerAlive;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI powerupText;

    private int score;
    private int lives;    

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemyOne", 1f, 3f);

        StartCoroutine(CreatePowerup());
        Createcoin();
        ScheduleNextCoinSpawn();

        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;

        lives = 3;
        livesText.text = "Lives: " + lives;

        isPlayerAlive=true;
        cloudSpeed = 1;       
    }

    // Update is called once per frame
    void Update()
    {
        Restart();   
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOne, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    IEnumerator CreatePowerup()
    {
        Instantiate(powerup, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3f, 6f));
        StartCoroutine(CreatePowerup());
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    public void EarnScore(int newScore)
    {
        score = score + newScore;
        scoreText.text = "Score: " + score;
    }

    public void LivesScore(int newLives)
    {
        lives = lives + newLives;
        livesText.text = "Lives: " + lives;
    }

    public void GameOver()
    {
        isPlayerAlive = false;
        CancelInvoke();
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        cloudSpeed = 0;
    }

    void Restart()
    {

    }
    void Createcoin()
    {
        if (coin != null)
        {
        Instantiate(coin, new Vector3(Random.Range(-12f, 12f), Random.Range(-8f, 8f), 0), Quaternion.identity);
         ScheduleNextCoinSpawn();
        }
        
    }
    void ScheduleNextCoinSpawn()
    {
         randomInterval = Random.Range(6f, 8f);
          Invoke("Createcoin", randomInterval);
    }

    public void UpdatePowerupText(string whichPowerup)
    {
        powerupText.text = whichPowerup;
    }

    public void PlayPowerUp()
    {
        AudioSource.PlayClipAtPoint(powerUp, Camera.main.transform.position);
    }

    public void PlayPowerDown()
    {
        AudioSource.PlayClipAtPoint(powerDown, Camera.main.transform.position);
    }

    public void PlayShieldUp() //this is the gainlife audio clip 
    {
        AudioSource.PlayClipAtPoint(shieldUp, Camera.main.transform.position);
    }

    public void PlayshieldDown()
    {
        AudioSource.PlayClipAtPoint(shieldDown, Camera.main.transform.position);
    }
}
