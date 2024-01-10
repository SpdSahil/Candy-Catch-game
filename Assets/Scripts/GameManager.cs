using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score;
    private int lives = 5;
    public bool gameOver = false;

    public TextMeshProUGUI scoreText;

    [SerializeField] private GameObject livesHolder;

    private void Awake()
    {
        Instance = this;
    }

    public void IncrementScore()
    {
        if(!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
        }
        
        //  Debug.Log("Score- " + score);
    }

    public void DecrementLives()
    {
        if(lives > 0)
        {
            lives--;

            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
        }
        
        if (lives <= 0)
        {
            gameOver = true;

            GameOver();
        }

        Debug.Log("Lives- " + lives);
    }

    public void IncrementLives()
    {
        if(lives > 0 && lives < 5)
        {
            lives++;

            livesHolder.transform.GetChild(lives-1).gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        CandySpawner.instance.StopSpawningCandies();

        GameObject.Find("Player").GetComponent<PlayerController>().isMovable = false;
    }
}
