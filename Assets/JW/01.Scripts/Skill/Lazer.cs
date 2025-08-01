using System;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] private SkillLazer _lazerSO;
    
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<EnemyHP>(out EnemyHP enemy))
        {
            enemy.TakeDamage(_lazerSO.AtkDMG);
        }
    }
}
