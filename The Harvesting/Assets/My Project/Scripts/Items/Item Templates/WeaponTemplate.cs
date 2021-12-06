using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new Weapon Template", menuName ="Data/Items/Weapon Template")]
    public class WeaponTemplate : GameItemTemplate<WeaponItem>, IWeaponTemplate
    {
        public Skill BaseWeaponSkill;
        public List<SkillAction> WeaponSkillActions;
        public List<ItemModifier> Attributes;
        public List<SkillAction> AdditionalEffects;

        public EquipmentSlotType EquipmenSlottType;
        public ItemModifier BaseDamageValue;
        public override WeaponItem Generate(int itemLevel, int requiredLevel )
        {
            WeaponItem weapon = new WeaponItem(this, requiredLevel, itemLevel);

            foreach(ItemModifier itemModifier in Attributes)
            {
                ItemStat itemStat;
                itemStat.Attribute = itemModifier.Attribute;
                itemStat.Value = Mathf.Round(Random.Range(itemModifier.MinValue, itemModifier.MaxValue) * ((100f + (itemLevel-1) * itemModifier.PercentageIncrementPerLevel)/100f));
                weapon.Attributes.Add(itemStat);
            }
            
            return weapon;
        }
    }
}