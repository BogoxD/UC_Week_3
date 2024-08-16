using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float spawnDelay = 5f;

    private int index;
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnDelay);
    }

    public void SpawnEnemy()
    {
        //get random enemy to spawn
        index = Random.Range(0, enemyPrefabs.Length);
        //instantiate enemy
        GameObject enemy = Instantiate(enemyPrefabs[index], new Vector3(transform.position.x + Random.Range(-5, 5), 1, transform.position.z), Quaternion.identity, transform);
    }

}
