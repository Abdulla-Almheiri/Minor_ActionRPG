using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new Weapon Template", menuName ="Data/Items/Weapon Template")]
    public class WeaponTemplate : ItemTemplate
    {
        public Skill WeaponSkill;
        public List<ItemModifier> Attributes;
        public EquipmentSlotType EquipmenSlottType;

        public override Item Generate(int itemLevel, int requiredLevel )
        {
            Weapon weapon = new Weapon(this);
            weapon.ItemLevel = itemLevel;
            weapon.RequiredLevel = Mathf.Max(0,requiredLevel);
            weapon.EquipmentSlotType = EquipmenSlottType;
            
            foreach(ItemModifier itemModifier in Attributes)
            {
                ItemStat itemStat;
                itemStat.Attribute = itemModifier.Attribute;
                itemStat.Value = Random.Range(itemModifier.BaseValue, itemModifier.MaxValue) * ((100f + itemLevel * itemModifier.PercentageIncrementPerLevel)/100f);
                weapon.Attributes.Add(itemStat);
            }
            
            return weapon;
        }
    }
}