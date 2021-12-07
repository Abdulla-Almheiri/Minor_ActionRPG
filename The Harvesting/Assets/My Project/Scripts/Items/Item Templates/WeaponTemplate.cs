using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new Weapon Template", menuName ="Data/Items/Weapon Template")]
    public class WeaponTemplate : EquipmentItemTemplate, IWeaponTemplate
    {
        public Skill BaseWeaponSkill;
        public List<SkillAction> WeaponSkillActions;
        public ItemModifier BaseDamageValue;

        public override EquipmentItem Generate()
        {
            throw new System.NotImplementedException();
        }

        public override GameItem Generate(int level, int requiredLevel)
        {
            throw new System.NotImplementedException();
        }

        WeaponItem IGameItemTemplate<WeaponItem>.Generate(int level, int requiredLevel)
        {
            throw new System.NotImplementedException();
        }
        /*public override EquipmentItem Generate(int itemLevel, int requiredLevel )
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
}*/
    }
}