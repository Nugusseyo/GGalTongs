using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "StatCardSO", menuName = "CardSO/StatCardSO")]
public class StatCardSO : CardSO
{
    [Header("������ �� ����")]
    public PlayerStat Stat;
    [Header("�ö󰡴� ���")]
    public float BonusValue;

    public void Apply()
    {
        Debug.Log("���ö��̵�");

        switch (Stat)
        {
            case PlayerStat.AttakSpeed:
                GunFire.Instance.minusAttackSpeed += BonusValue;
                CurrentLevel++;
                break;
            case PlayerStat.Damage:
                GunFire.Instance.BulletPowerUp(BonusValue);
                CurrentLevel++;
                break;
            case PlayerStat.MaxHp:
                HealthBarUI.Instance.PlusMaxHealth(BonusValue);
                CurrentLevel++;
                break;
            case PlayerStat.MoveSpeed:
                PlayerMovement.Instance.plusMoveSpeed += BonusValue;
                CurrentLevel++;
                break;
        }
    }
}
