using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "StatCardSO", menuName = "CardSO/StatCardSO")]
public class StatCardSO : CardSO
{
    [Header("영향을 줄 스탯")]
    public PlayerStat Stat;
    [Header("올라가는 계수")]
    public float BonusValue;

    public void Apply()
    {
        Debug.Log("어플라이됨");

        switch (Stat)
        {
            case PlayerStat.AttakSpeed:
                GunFire.Instance.minusAttackSpeed += BonusValue;
                Level++;
                break;
            case PlayerStat.Damage:
                GunFire.Instance.BulletPowerUp(BonusValue);
                Level++;
                break;
            case PlayerStat.MaxHp:
                HealthBarUI.Instance.PlusMaxHealth(BonusValue);
                Level++;
                break;
            case PlayerStat.MoveSpeed:
                PlayerMovement.Instance.plusMoveSpeed += BonusValue;
                Level++;
                break;
        }
    }
}
