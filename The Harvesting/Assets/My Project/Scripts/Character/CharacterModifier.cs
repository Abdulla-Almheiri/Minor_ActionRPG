using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    [System.Serializable]
    public struct CharacterModifier
    {
        public MyModifier Base, Equipment, Skills;
        public float Value()
        {
            var value = Base.BaseValue + Equipment.BaseValue + Skills.BaseValue;
            value *= (100f + Base.Percentage) / 100f;
            value *= (100f + Equipment.Percentage) / 100f;
            value *= (100f + Skills.Percentage) / 100f;

            return value;
        }

    }

    public struct MyModifier
    {
        public float BaseValue;
        public float Percentage;
    }
}