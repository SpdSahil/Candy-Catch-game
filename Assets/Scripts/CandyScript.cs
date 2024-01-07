using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            GameManager.Instance.IncrementScore();
        }
        else if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
