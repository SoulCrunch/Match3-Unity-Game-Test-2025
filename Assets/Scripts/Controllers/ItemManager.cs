using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    [SerializeField] private ItemDatabase itemDatabase;
    [SerializeField] private int initialPoolSize = 10;

    private Dictionary<eNormalType, ObjectPool> normalPools;
    private Dictionary<eBonusType, ObjectPool> bonusPools;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        itemDatabase.Init();

        normalPools = new Dictionary<eNormalType, ObjectPool>();
        bonusPools = new Dictionary<eBonusType, ObjectPool>();
    }

    public void Init(Transform boardController)
    {
        foreach (eNormalType type in System.Enum.GetValues(typeof(eNormalType)))
        {
            if (type == eNormalType.NONE) continue;
            GameObject prefab = itemDatabase.GetItem(type);
            normalPools[type] = new ObjectPool(prefab, initialPoolSize, boardController);
        }

        foreach (eBonusType type in System.Enum.GetValues(typeof(eBonusType)))
        {
            if (type == eBonusType.NONE) continue;

            GameObject prefab = itemDatabase.GetItem(type);
            bonusPools[type] = new ObjectPool(prefab, initialPoolSize, boardController);
        }
    }

    public GameObject GetItem(eNormalType type)
    {
        if (normalPools.TryGetValue(type, out var pool))
            return pool.Get();
        else
            return itemDatabase.GetItem(type);
    }

    public GameObject GetItem(eBonusType type)
    {
        if (bonusPools.TryGetValue(type, out var pool))
            return pool.Get();
        else
            return itemDatabase.GetItem(type);
    }

    public void ReturnItem(GameObject obj)
    {
        var itemType = obj.GetComponent<ItemWithType>();
        if (itemType == null)
        {
            Destroy(obj);
            return;
        }

        if (itemType.NormalType != eNormalType.NONE && normalPools.ContainsKey(itemType.NormalType))
            normalPools[itemType.NormalType].Return(obj);
        else if (itemType.BonusType != eBonusType.NONE && bonusPools.ContainsKey(itemType.BonusType))
            bonusPools[itemType.BonusType].Return(obj);
        else
            Destroy(obj);
    }
}
