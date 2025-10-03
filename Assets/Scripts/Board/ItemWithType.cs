using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWithType : MonoBehaviour
{
    [SerializeField] private eNormalType normalType;
    [SerializeField] private eBonusType bonusType;

    public eNormalType NormalType => normalType;
    public eBonusType BonusType => bonusType;
}
