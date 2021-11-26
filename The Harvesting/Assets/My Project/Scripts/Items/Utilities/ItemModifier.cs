using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [System.Serializable]
    public struct ItemModifier
    {
        public Attribute Attribute;
        public float BaseValue, MaxValue, PercentageIncrementPerLevel;
    }
}