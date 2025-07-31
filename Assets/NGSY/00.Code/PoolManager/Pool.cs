﻿using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private Stack<IPoolable> _pool;
    private Transform _parent;
    private IPoolable _poolable;
    private GameObject _prefab;

    public Pool(IPoolable poolable, Transform parent, int initCount)
    {
        _pool = new Stack<IPoolable>();
        _parent = parent;
        _poolable = poolable;
        _prefab = poolable.GameObject;

        for (int i = 0; i < initCount; i++)
        {
            GameObject item = Object.Instantiate(_prefab, _parent);
            item.SetActive(false); //처음 생성되는 아이템은 꺼준다.
            item.name = _poolable.ItemName; //아이템 이름을 초기화시켜준다.
            IPoolable poolableItem = item.GetComponent<IPoolable>();
            _pool.Push(poolableItem);
        }
    }

    public IPoolable Pop()
    {
        IPoolable item = null;
        if (_pool.Count == 0)
        {
            GameObject gameObj = Object.Instantiate(_prefab, _parent);
            gameObj.name = _poolable.ItemName;
            item = gameObj.GetComponent<IPoolable>();
        }
        else
        {
            item = _pool.Pop();
            item.GameObject.SetActive(true); //꺼져있던 아이템을 활성화 시켜준다.
        }

        return item;
    }

    public void Push(IPoolable item)
    {
        item.GameObject.SetActive(false);
        _pool.Push(item);
    }
}