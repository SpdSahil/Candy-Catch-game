using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] private float maxX;
    [SerializeField] [Range(0.5f,2f)] private float minWaitTime;
    [SerializeField] [Range(2.5f,5.5f)] private float maxWaitTime;
    [SerializeField] private GameObject[] candies;
    [SerializeField] private bool isPlaying = true;

    public static CandySpawner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Spawning();
    }

    private void SpawnCandy()
    {
        int randCandy = Random.Range(0, candies.Length);
        float randomX = Random.Range(-maxX, maxX);

        Vector2 randomPos = new Vector2(randomX, transform.position.y);

        Quaternion randomRotate = Random.rotation;
        randomRotate.x = 0;
        randomRotate.y = 0;

        Instantiate(candies[randCandy], randomPos, randomRotate);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(3f);

        while(true)
        {
            SpawnCandy();

            float spawnInterval = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Spawning()
    {
        if (isPlaying)
        {
            StartCoroutine("SpawnCandies");
        }
    }

    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies");
    }
}
