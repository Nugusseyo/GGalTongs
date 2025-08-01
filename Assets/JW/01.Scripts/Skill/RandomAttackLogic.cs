using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomAttackLogic : MonoBehaviour
{
    public static RandomAttackLogic Instance { get; private set; }
    private Camera _camera;
    [SerializeField] private GameObject _effect;

    private void Awake()
    {
        _camera = Camera.main;
        if (Instance == null)
            Instance = this;
    }

    public void UseSkill()
    {
        Vector3 topright = _camera.ViewportToWorldPoint(new Vector3(1, 1, -10));
        Vector3 bottomLeft = _camera.ViewportToWorldPoint(new Vector3(0, 0, -10));

        float posX = Random.Range(bottomLeft.x - 5, topright.x + 5);
        float posY = Random.Range(bottomLeft.y - 5, topright.y + 5);
        Vector3 spawnPos = new Vector3(posX, posY, 0);

        GameObject effect = Instantiate(_effect, spawnPos, Quaternion.identity);
        
        Destroy(effect , 2f);
        
    }

    private void OnDrawGizmos()
    {
    }
}
