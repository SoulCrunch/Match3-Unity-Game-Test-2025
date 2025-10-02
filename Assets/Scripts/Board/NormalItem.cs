using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItem : Item
{
    public eNormalType ItemType = eNormalType.NONE;

    public void SetType(eNormalType type)
    {
        ItemType = type;
        normalType = type;
    }

    internal override bool IsSameType(Item other)
    {
        NormalItem it = other as NormalItem;

        return it != null && it.ItemType == this.ItemType;
    }
}
