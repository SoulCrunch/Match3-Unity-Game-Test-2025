using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;

public class Utils
{
    public static eNormalType GetRandomNormalType()
    {
        var values = Enum.GetValues(typeof(eNormalType))
                         .Cast<eNormalType>()
                         .Where(v => v != eNormalType.NONE)
                         .ToArray();

        return values[URandom.Range(0, values.Length)];
    }


    public static eNormalType GetRandomNormalTypeExcept(eNormalType[] excluded)
    {
        var values = Enum.GetValues(typeof(eNormalType))
                         .Cast<eNormalType>()
                         .Where(v => v != eNormalType.NONE && !excluded.Contains(v))
                         .ToArray();

        return values[URandom.Range(0, values.Length)];
    }

}
