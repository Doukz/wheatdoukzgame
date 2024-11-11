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

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;    

    private int score;
    private int lives;    

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemyOne", 1f, 3f);
        CreateSky();
        Createcoin();
        ScheduleNextCoinSpawn();
        score = 0;
        scoreText.text = "Score: " + score;

        lives = 3;
        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOne, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
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
}
