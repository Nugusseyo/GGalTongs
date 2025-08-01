using System;
using Unity.Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "RandomAttack", menuName = "SkillSO/RandomAttack")]
public class RandomAttack : SkillSO
{
    //랜덤한 위치에 레이저 터뜨리는 기술인데 이름 잘 생각이 안났음 양해부탁
    public float AtkDMG = 2;
    private Camera _camera;
    private int _spawnLimit;
    [SerializeField] private AudioClip _audio;
    
    
    public override void Initialize()
    {
        base.Initialize();
        AtkDMG = 2;
        ActiveCount = CurrentLevel;
    }

    public override void ResetSkillData()
    {
        base.ResetSkillData();
        CurrentLevel = 0;
        ActiveCount = CurrentLevel + 5;
    }

    protected override void Active()
    {
        for (int i = 0; i < ActiveCount; i++)
        {
            //사운드 재생 1
            RandomAttackLogic.Instance?.UseSkill();
        }
    }
    
    public override void Upgrade()
    {
        if (CurrentLevel < LevelLimit)
        {
            CurrentLevel++;
            ActiveCount = CurrentLevel;
        }
        
    }
}
