using System;
using Unity.Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "RandomAttack", menuName = "SkillSO/RandomAttack")]
public class RandomAttack : SkillSO
{
    //랜덤한 위치에 레이저 터뜨리는 기술인데 이름 잘 생각이 안났음 양해부탁
    [SerializeField] private GameObject _effect;
    private Camera _camera;

    public void Initialize()
    {
        base.Initialize();
        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    protected override void Active()
    {
        Vector3 topright = _camera.ViewportToScreenPoint(new Vector3(1, 1, -10));
        Vector3 bottomLeft = _camera.ViewportToScreenPoint(new Vector3(0, 0, -10));

        float posX = Random.Range(bottomLeft.x, topright.x);
        float posY = Random.Range(bottomLeft.y, topright.y);
        Vector3 spawnPos = new Vector3(posX, posY, 0);

        Instantiate(_effect, spawnPos, Quaternion.identity);
    }

    public override void Upgrade()
    {
        throw new NotImplementedException();
    }
}
