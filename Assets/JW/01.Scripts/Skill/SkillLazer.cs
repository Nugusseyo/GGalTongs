using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillLazer", menuName = "SkillSO/SkillLazer")]
public class SkillLazer : SkillSO
{
    [SerializeField] private GameObject _lazer;
    [SerializeField] private GameObject spawnPoint;
    public override void Initialize()
    {
        base.Initialize();
        spawnPoint = GameObject.Find("Test");
        ActiveCount = CurrentLevel;
    }

    protected override void Active()
    {
        for (int i = 0; i < ActiveCount; i++)
        { 
            int dir = Random.Range(0, 361);
            Quaternion rotation = Quaternion.Euler(0,0,dir);
        
            Vector3 offset = Vector3.up * 0.9f;
            Vector3 spawnPos = spawnPoint.transform.position + rotation * offset;
        
            GameObject lazer = Instantiate(_lazer, spawnPos, rotation);
            Destroy(lazer, 2);
            lazer.GetComponent<Rigidbody2D>().linearVelocity = lazer.transform.up * 30;
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
