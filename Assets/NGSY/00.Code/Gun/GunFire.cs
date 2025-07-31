using System;
using System.Collections;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public static GunFire Instance;
    public float AttackSpeed { get; private set; }
    public float minusAttackSpeed;

    private float _basePower = 10f;
    public float AttackPower { get; private set; }
    
    private void Awake()
    {
        AttackPower = _basePower;
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

    public void BulletPowerUp(float power)
    {
        AttackPower = _basePower + power;
    }

    private IEnumerator BulletShot(float coolTime)
    {
        PoolManager.Instance.Pop("Bullet");
        yield return new WaitForSeconds(coolTime);
        StartCoroutine(BulletShot((AttackSpeed - minusAttackSpeed)/100));
    }
}
