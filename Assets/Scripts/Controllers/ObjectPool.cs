using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private GameObject prefab;
    private Transform parent;
    private Queue<GameObject> pool = new Queue<GameObject>();

    public ObjectPool(GameObject prefab, int initialSize = 5, Transform parent = null)
    {
        this.prefab = prefab;
        this.parent = parent;

        for (int i = 0; i < initialSize; i++)
            pool.Enqueue(CreateNew());
    }

    private GameObject CreateNew()
    {
        GameObject obj = Object.Instantiate(prefab, parent);
        obj.SetActive(false);
        return obj;
    }

    public GameObject Get()
    {
        GameObject obj = pool.Count > 0 ? pool.Dequeue() : CreateNew();
        obj.SetActive(true);
        return obj;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
