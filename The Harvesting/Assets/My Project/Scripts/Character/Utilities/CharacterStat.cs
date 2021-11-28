using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class CharacterStat
    {
        
        public float BaseValue;
        public float PercentageBonus;
        public object Source;

        public float Value()
        {
            return BaseValue * (100f + PercentageBonus) / 100f;
        }
    }
}