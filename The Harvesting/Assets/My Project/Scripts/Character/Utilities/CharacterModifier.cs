using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    [System.Serializable]
    public class CharacterModifier
    {
        public MyModifier Base, Equipment, Skills;
        public float FinalValue()
        {
            var value = Base.FlatValue + Equipment.FlatValue + Skills.FlatValue;
            value *= (100f + Base.Percentage) / 100f;
            value *= (100f + Equipment.Percentage) / 100f;
            value *= (100f + Skills.Percentage) / 100f;

            return value;
        }

        public CharacterModifier(float baseValue)
        {
            Base.FlatValue = baseValue;
        }

    }

    public struct MyModifier
    {
        public float FlatValue;
        public float Percentage;
    }
}