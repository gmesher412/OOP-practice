using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;
    private int spawnRange = 24;
    private int smallSpawnDelay, normalSpawnStart, normalSpawnDelay, bigSpawnStart, bigSpawnDelay;
    private GameController gameController;
    void Awake()
    {
        smallSpawnDelay = 2;
        normalSpawnStart = 5;
        normalSpawnDelay = 5;
        bigSpawnStart = 10;
        bigSpawnDelay = 8;

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Start()
    {
        StartCoroutine(SmallSpawner());
        StartCoroutine(NormalSpawnerStart());
        StartCoroutine(BigSpawnerStart());
    }

    void Update()
    {
        if(gameController.gameOver)
        {
            StopAllCoroutines();
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        var spawnPosX = Random.Range(-spawnRange, spawnRange);
        var spawnPosZ = Random.Range(-spawnRange, spawnRange);
        
        var randomPos =  new Vector3(spawnPosX, 0.348f, spawnPosZ);
        
        return randomPos;
    }

     // Spawns baby enemies at set time intervals
    IEnumerator SmallSpawner()
    {
        yield return new WaitForSeconds(smallSpawnDelay);
        Instantiate(enemies[0], GenerateSpawnPosition(), enemies[0].transform.rotation);
        StartCoroutine(SmallSpawner());
    }

    // Spawns the first normal enemy at a set time
    // Then starts the interval spawner
    IEnumerator NormalSpawnerStart()
    {
        yield return new WaitForSeconds(normalSpawnStart);
        Instantiate(enemies[1], GenerateSpawnPosition(), enemies[1].transform.rotation);
        StartCoroutine(NormalSpawner());
    }

    // Normal enemy interval spawner
    IEnumerator NormalSpawner()
    {
        yield return new WaitForSeconds(normalSpawnDelay);
        Instantiate(enemies[1], GenerateSpawnPosition(), enemies[1].transform.rotation);
        StartCoroutine(NormalSpawner());
    }

    // Spawns the first big enemy at a set time
    // Then starts the big enemy interval spawner
    IEnumerator BigSpawnerStart()
    {
        yield return new WaitForSeconds(bigSpawnStart);
        Instantiate(enemies[2], GenerateSpawnPosition(), enemies[2].transform.rotation);
        StartCoroutine(BigSpawner());
    }

    // Big enemy interval spawner
    IEnumerator BigSpawner()
    {
        yield return new WaitForSeconds(bigSpawnDelay);
        Instantiate(enemies[2], GenerateSpawnPosition(), enemies[2].transform.rotation);
        StartCoroutine(BigSpawner());
    }
}
