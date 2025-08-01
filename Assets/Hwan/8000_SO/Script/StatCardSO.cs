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
