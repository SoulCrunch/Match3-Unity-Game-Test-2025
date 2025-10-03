using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Database/Item Database")]
public class ItemDatabase : ScriptableObject
{
    [SerializeField] private List<GameObject> allItemPrefabs = new List<GameObject>();

    private Dictionary<eNormalType, GameObject> normalDict;
    private Dictionary<eBonusType, GameObject> bonusDict;

    public void Init()
    {
        normalDict = new Dictionary<eNormalType, GameObject>();
        bonusDict = new Dictionary<eBonusType, GameObject>();

        foreach (var prefab in allItemPrefabs)
        {
            var itemType = prefab.GetComponent<ItemWithType>();
            if (itemType == null)
            {
                Debug.LogError($"[ItemDatabase] Prefab {prefab.name} is missing ItemWithType component!");
                continue;
            }

            if (itemType.NormalType != eNormalType.NONE)
            {
                normalDict[itemType.NormalType] = prefab;
            }

            if (itemType.BonusType != eBonusType.NONE)
            {
                bonusDict[itemType.BonusType] = prefab;
            }
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
