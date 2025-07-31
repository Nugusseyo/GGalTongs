using System;
using System.Collections;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public static GunFire Instance;
    public float AttackSpeed { get; private set; }
    public float minusAttackSpeed;

    private void Awake()
    {
        AttackSpeed = 200;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        StartCoroutine(BulletShot(AttackSpeed / 100));
    }

    private IEnumerator BulletShot(float coolTime)
    {
        IPoolable bullet = PoolManager.Instance.Pop("Bullet");
        yield return new WaitForSeconds(coolTime);
        StartCoroutine(BulletShot((AttackSpeed - minusAttackSpeed)/100));
    }
}
