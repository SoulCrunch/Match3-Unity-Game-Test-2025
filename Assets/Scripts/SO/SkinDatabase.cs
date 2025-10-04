using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinDatabase", menuName = "Database/Skin Database")]
public class SkinDatabase : ScriptableObject
{
    [System.Serializable]
    private class NormalSkin
    {
        public eNormalType type = eNormalType.NONE;
        public Sprite sprite;
    }

    [System.Serializable]
    private class BonusSkin
    {
        public eBonusType type = eBonusType.NONE;
        public Sprite sprite;
    }

    [SerializeField] private NormalSkin[] normalSkins;
    [SerializeField] private BonusSkin[] bonusSkins;

    private Dictionary<eNormalType, Sprite> normalSkinDict;
    private Dictionary<eBonusType, Sprite> bonusSkinDict;

    private void OnEnable()
    {
        int normalCount = Enum.GetValues(typeof(eNormalType)).Length - 1; // exclude NONE
        int bonusCount = Enum.GetValues(typeof(eBonusType)).Length - 1;  // exclude NONE

        if (normalSkins.Length != normalCount)
            Debug.LogError($"[SkinDatabase] Normal skins mismatch. Expected {normalCount}, got {normalSkins.Length}");

        if (bonusSkins.Length != bonusCount)
            Debug.LogError($"[SkinDatabase] Bonus skins mismatch. Expected {bonusCount}, got {bonusSkins.Length}");

        BuildDictionaries();
    }

    private void BuildDictionaries()
    {
        normalSkinDict = new Dictionary<eNormalType, Sprite>();
        bonusSkinDict = new Dictionary<eBonusType, Sprite>();

        foreach (var skin in normalSkins)
        {
            if (skin.type == eNormalType.NONE) continue;

            normalSkinDict.Add(skin.type, skin.sprite);
        }

        foreach (var skin in bonusSkins)
        {
            if (skin.type == eBonusType.NONE) continue;

            bonusSkinDict.Add(skin.type, skin.sprite);
        }
    }

    public Sprite GetSkinForType(eNormalType type)
    {
        if (type == eNormalType.NONE) return null;

        if (normalSkinDict.TryGetValue(type, out var sprite))
            return sprite;

        Debug.LogWarning($"[SkinDatabase] No Normal skin found for {type}");
        return null;
    }

    public Sprite GetSkinForType(eBonusType type)
    {
        if (type == eBonusType.NONE) return null;

        if (bonusSkinDict.TryGetValue(type, out var sprite))
            return sprite;

        Debug.LogWarning($"[SkinDatabase] No Bonus skin found for {type}");
        return null;
    }
}
