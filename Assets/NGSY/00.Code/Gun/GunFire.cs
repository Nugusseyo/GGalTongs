using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GunFire : MonoBehaviour
{
    public UnityEvent shootEvent;
    
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
        yield return new WaitForSeconds(coolTime);
        IPoolable bullet = PoolManager.Instance.Pop("Bullet");
        GameObject bulletGO = bullet.GameObject;
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 direction = (mousePos - bulletGO.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bulletGO.transform.rotation = Quaternion.Euler(0, 0, angle - 270);
        
        shootEvent?.Invoke();
        StartCoroutine(BulletShot((AttackSpeed - minusAttackSpeed)/100));
    }
}
