using System;
using System.Collections;
using UnityEngine;

public class BulletMovement : MonoBehaviour, IPoolable
{
    private Transform _fireTrm; 
    private Rigidbody2D _rigidbody2D;
    public Vector2 MoveDir { get; private set; }

    public float MoveSpeed { get; private set; }
    public string ItemName => "Bullet";
    public GameObject GameObject => gameObject;

    private readonly float _lifeTime = 2f;
    private void Awake()
    {
        MoveSpeed = 30f;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _fireTrm = GameObject.Find("FirePos").GetComponent<Transform>();
        transform.position = _fireTrm.transform.position;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MoveDir = mousePosition - transform.position;

        _rigidbody2D.linearVelocity = MoveDir.normalized * MoveSpeed;

        StartCoroutine(DestroySelf(_lifeTime));
    }

    private IEnumerator DestroySelf(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        PoolManager.Instance.Push(this);
    }

    public void ResetItem()
    {
        
    }
}
