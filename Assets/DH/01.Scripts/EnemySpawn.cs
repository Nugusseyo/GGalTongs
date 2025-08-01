using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform spawnPoint;
    public float spawn = 3f;

    void Start()
    {
        StartCoroutine(SpawnReturn());
    }

    private IEnumerator SpawnReturn()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawn);
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0) return;

        int ran = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[ran], spawnPoint.position, Quaternion.identity);
    }
}