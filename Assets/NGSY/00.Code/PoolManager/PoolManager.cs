using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private PoolingListSO poolList;

    private Dictionary<string, Pool> _pools;

    protected override void Awake()
    {
        base.Awake();
        _pools = new Dictionary<string, Pool>();

        foreach (PoolItem item in poolList.items)
        {
            CreatePool(item.prefab, item.count);
        }
    }

    private void CreatePool(GameObject item, int count)
    {
        IPoolable poolable = item.GetComponent<IPoolable>();
        if(poolable == null)
        {
            return;
        }
        Pool pool = new Pool(poolable, transform, count);
        _pools.Add(poolable.ItemName, pool);
    }

    public IPoolable Pop(string itemName)
    {
        if(_pools.ContainsKey(itemName))
        {
            IPoolable item = _pools[itemName].Pop();
            item.ResetItem();
            return item;
        }
        return null;
    }

    public void Push(IPoolable returnItem)
    {
        if (_pools.ContainsKey(returnItem.ItemName))
        {
            _pools[returnItem.ItemName].Push(returnItem);
            return;
        }
    }
}
