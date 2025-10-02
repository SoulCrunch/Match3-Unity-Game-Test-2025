using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Database/Item Database")]
public class ItemDatabase : ScriptableObject
{
    [Serializable]
    private class Item_N
    {
        public eNormalType type;
        public GameObject prefab;
    }

    [Serializable]
    private class Item_S
    {
        public eBonusType type;
        public GameObject prefab;
    }

    [SerializeField] private List<Item_N> allNormalItemPrefabs = new List<Item_N>();
    [SerializeField] private List<Item_S> allBonusItemPrefabs = new List<Item_S>();

    private Dictionary<eNormalType, GameObject> normalDict;
    private Dictionary<eBonusType, GameObject> bonusDict;

    public void Init()
    {
        normalDict = new Dictionary<eNormalType, GameObject>();
        bonusDict = new Dictionary<eBonusType, GameObject>();

        foreach (var n in allNormalItemPrefabs)
        {
            if (n.prefab == null)
            {
                Debug.LogError($"Missing prefab for normal type: {n.type}");
            }

            normalDict[n.type] = n.prefab;
        }

        foreach (var b in allBonusItemPrefabs)
        {
            if (b.prefab == null)
            {
                Debug.LogError($"Missing prefab for normal type: {b.type}");
            }

            bonusDict[b.type] = b.prefab;
        }
    }

    public GameObject GetItem(eNormalType type)
    {
        return normalDict.TryGetValue(type, out var prefab) ? prefab : null;
    }

    public GameObject GetItem(eBonusType type)
    {
        return bonusDict.TryGetValue(type, out var prefab) ? prefab : null;
    }
}


