using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;       // 추적 속도

    private Transform player;

    void Start()
    {

        GameObject yunkyu = GameObject.FindWithTag("Player");
        if (yunkyu != null) player = yunkyu.transform;
    }

    void Update()
    {
        if (player == null) return;


        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
