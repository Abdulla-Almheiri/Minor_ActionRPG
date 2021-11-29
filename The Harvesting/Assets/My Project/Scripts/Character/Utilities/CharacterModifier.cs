using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    [System.Serializable]
    public class CharacterModifier
    {
        public float BaseAdd = 0f, BaseMulti = 0f, SkillsAdd = 0f, SkillsMulti = 0f, EquipmentAdd = 0f, EquipmentMulti = 0f;
        public Attribute Attribute;
        public object Source;
        public float FinalValue()
        {
            var value = BaseAdd + SkillsAdd + EquipmentAdd;
            value *= 1f + (BaseMulti / 100f);
            value *= 1f + (SkillsMulti / 100f);
            value *= 1f + (EquipmentMulti / 100f);

            return value;
        }

        public CharacterModifier(float baseValue, Attribute attribute)
        {
            BaseAdd = baseValue;
            Attribute = attribute;
        }

        public CharacterModifier()
        {
            BaseAdd = 0f;
        }
    }

}