using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    private static int candyStack = 0;
    [SerializeField] private int maxCandyStack = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            GameManager.Instance.IncrementScore();

            candyStack++;
            Debug.Log(candyStack);
            if(candyStack == maxCandyStack)
            {
                candyStack = 0;
                GameManager.Instance.IncrementLives();
            }
        }
        else if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);

            GameManager.Instance.DecrementLives();

            candyStack = 0;
            Debug.Log(candyStack);
        }
    }
}
