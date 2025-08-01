using System;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] private float _attackDMG = 5;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<EnemyHP>(out EnemyHP enemy))
        {
            enemy.TakeDamage(_attackDMG);
        }
    }
}
