using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LB_Pool : MonoBehaviour
{

    public GameObject PoolableObjectPrefab;

    protected Stack<LB_Poolable> pool;
    protected List<LB_Poolable> livingItems;

    public void PopulatePool(int population)
    {
        livingItems = new List<LB_Poolable>();
        pool = new Stack<LB_Poolable>();

        for (int i = 0; i < population; i++)
        {
            AddObjectToPool(GenerateObject());
        }
    }

    public void AddObjectToPool(LB_Poolable poolable)
    {
        pool.Push(poolable);
        poolable.OnDeactivate();
    }

    private LB_Poolable GenerateObject()
    {
        var item = Instantiate(PoolableObjectPrefab).GetComponent<LB_Poolable>();
        item.Initialize();
        item.OnDeactivate();
        return item;
    }

    public LB_Poolable GetPoolable()
    {
        if (pool.Count == 0)
        {
            AddObjectToPool(GenerateObject());
        }

        var item = pool.Pop();
        item.OnActivated();
        livingItems.Add(item);

        return item;
    }
}
