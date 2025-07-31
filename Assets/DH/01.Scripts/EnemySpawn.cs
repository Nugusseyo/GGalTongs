using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawn = 3f;

    void Start()
    {
        StartCoroutine(SpawnStart());
    }

    IEnumerator SpawnStart()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawn);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
