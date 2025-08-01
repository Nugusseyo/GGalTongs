using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyScanSkill", menuName = "SkillSO/EnemyScanSkill")]
public class EnemyScanSkill : SkillSO
{
    [SerializeField] private List<GameObject> _enemyList = new List<GameObject>();
    [SerializeField] private GameObject _playerPos; //플레이어 위치를 가져오기 위해 오브젝트 가져옴
    [SerializeField] private GameObject _scanEffect; 
    [SerializeField] private float _radious = 15;
    public override void Initialize()
    {
        base.Initialize();
        if (_playerPos == null)
        {
            _playerPos = GameObject.Find("Player");
        }
    }

    protected override void ResetSkillData()
    {
        base.ResetSkillData();
        ActiveCount = CurrentLevel + 6;
    }

    protected override void Active()
    {
        _enemyList.Clear();
        int limit = ActiveCount;
        
        Collider2D[] hits = Physics2D.OverlapCircleAll(_playerPos.transform.position, _radious);
        foreach (var hit in hits)
        {
            if (hit.gameObject.CompareTag("Enemy"))
            {
                _enemyList.Add(hit.gameObject);
                ActiveCount--;
                Instantiate(_scanEffect);
                _scanEffect.GetComponent<ScanEffect>().Follow(hit.gameObject);
                if (ActiveCount <= 0)
                    break;
            }
        }
        Debug.Log($"hits 카운트 : {hits.Length}, 에너미 리스트 : {_enemyList}");
        ResetSkillData();
    }

    public override void Upgrade()
    {
        if (CurrentLevel < LevelLimit)
        {
            CurrentLevel++;
            
            Debug.Log(CurrentLevel);
            ResetSkillData();
        }
    }
}
