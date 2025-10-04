using System;
using UnityEngine;

public class ItemReskin : MonoBehaviour
{
    [SerializeField] private ItemDatabase items;
    [SerializeField] private SkinDatabase skins;

    private void Awake()
    {
        foreach (eNormalType type in Enum.GetValues(typeof(eNormalType)))
        {
            if (type == eNormalType.NONE) continue;

            var item = items.GetItem(type);
            if (item != null)
            {
                var renderer = item.GetComponent<SpriteRenderer>();
                if (renderer != null)
                    renderer.sprite = skins.GetSkinForType(type);
            }
        }

        foreach (eBonusType type in Enum.GetValues(typeof(eBonusType)))
        {
            if (type == eBonusType.NONE) continue;

            var item = items.GetItem(type);
            if (item != null)
            {
                var renderer = item.GetComponent<SpriteRenderer>();
                if (renderer != null)
                    renderer.sprite = skins.GetSkinForType(type);
            }
        }
    }
}
