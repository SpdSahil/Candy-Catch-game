using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score;
    private bool gameOver = false;

    //[SerializeField] private Text scoreText;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
        Debug.Log("Score- " + score);
    }
}
