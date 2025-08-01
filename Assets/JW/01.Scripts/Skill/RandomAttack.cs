using System;
using Unity.Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "RandomAttack", menuName = "SkillSO/RandomAttack")]
public class RandomAttack : SkillSO
{
    //랜덤한 위치에 레이저 터뜨리는 기술인데 이름 잘 생각이 안났음 양해부탁
    
    private Camera _camera;
    private int _spawnLimit;
    public void Initialize()
    {
        base.Initialize();
        _spawnLimit = CurrentLevel + 2;
    }

    protected override void Active()
    {
        for (int i = 0; i < _spawnLimit; i++)
        {
            RandomAttackLogic.Instance?.UseSkill();
        }
    }

    public override void Upgrade()
    {
        Initialize();
        CurrentLevel++;
    }
}
