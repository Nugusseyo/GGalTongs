using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    private float _spawnDelay = 5f;
    private GameObject enemyGO;

    private void Start()
    {
        StartCoroutine(EnemySpawnCoroutine(_spawnDelay));
    }

    private IEnumerator EnemySpawnCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        int type = Random.Range(0, 3);
        if (type == 0)
        {
            IPoolable enemy = PoolManager.Instance.Pop("RED");
            enemyGO = enemy.GameObject;
        }
        else if (type == 1)
        {
            IPoolable enemy = PoolManager.Instance.Pop("BLUE");
            enemyGO = enemy.GameObject;
        }
        else
        {
            IPoolable enemy = PoolManager.Instance.Pop("GRAY");
            enemyGO = enemy.GameObject;
        }
        enemyGO.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        if (_spawnDelay - ExpManager.Instance.CurrentLevel / 10 < 0.4)
        {
            StartCoroutine(EnemySpawnCoroutine(_spawnDelay - (float)4.6));
        }
        else
        {
            StartCoroutine(EnemySpawnCoroutine(_spawnDelay - (ExpManager.Instance.CurrentLevel / 5)));
        }
    }
}