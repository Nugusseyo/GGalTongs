using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [field:SerializeField] public Rigidbody2D RbCompo { get; private set; }

    private Vector2 _moveDir;

    private float _baseMoveSpeed = 5f;
    public float plusMoveSpeed;
    public static PlayerMovement Instance { get; private set; }

    private void Awake()
    {
        RbCompo = GetComponentInParent<Rigidbody2D>();
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        RbCompo.linearVelocity = _moveDir.normalized * (plusMoveSpeed + _baseMoveSpeed);
    }

    public void SetMoveDir(Vector2 moveDir) => _moveDir = moveDir;
}
