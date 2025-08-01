using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class ScanEffect : MonoBehaviour
{
    public static ScanEffect Instance { get; private set; }

    private void Awake()
    {
        DOTween.Init(false,true,LogBehaviour.Verbose).SetCapacity(200, 50);
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        transform.DOScale(3f, 0.5f).OnComplete((() =>
        {
            transform.DOScale(0, 0.5f); 
            Destroy(gameObject, 0.5f);
        }));
    }
    
    public void Follow(GameObject enemy)
    {
        transform.position = enemy.transform.position;
    }
}
