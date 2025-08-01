using UnityEngine;

public class Enemy : MonoBehaviour, IPoolable
{
    public float moveSpeed = 2f;
    public float attackRange = 1.5f;
    public float damage = 10f;
    public float attackCooldown = 1.0f;

    private Transform _player;
    private bool _attacking = false;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
            _player = player.transform;
    }	

    void Update()
    {
        if (_player == null) return;

        float dist = Vector3.Distance(transform.position, _player.position);
        if (dist > attackRange)
        {
            
            Vector3 dir = (_player.position - transform.position).normalized;
            transform.position += dir * (moveSpeed * Time.deltaTime);
        }
        else
        {
            if (!_attacking)
                StartCoroutine(DoAttack());
        }
    }

    private System.Collections.IEnumerator DoAttack()
    {
        _attacking = true;


        yield return new WaitForSeconds(0.5f);


        if (HealthBarUI.Instance != null)
        {
            HealthBarUI.Instance.PlayerDamaged(damage);
        }


        yield return new WaitForSeconds(attackCooldown);

        _attacking = false; 
    }

    private void OnDestroy()
    {
        float ran = Random.Range(0, 100);
        if (ran < 7)
        {
            TorchItemUi.Instance.AddTorchItme(1);
        }
    }

    public string ItemName => gameObject.name;
    public GameObject GameObject => gameObject;
    public void ResetItem()
    {
        
    }
}