using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
   /* public class WeaponItem : EquipmentItem, IWeaponItem
    {
        public int ItemLevel { get; protected set; }
        public new WeaponTemplate<WeaponItem> Template { get; protected set; }
        public int RequiredLevel { get; protected set; }
        public EquipmentSlotType EquipmentSlotType { get; protected set; }
        public float DamageValue { get; protected set; }
        public List<ItemStat> Attributes { get; protected set; } = new List<ItemStat>();

        public WeaponItem(WeaponTemplate weaponTemplate, int requiredLevel, int itemLevel)
        {
            Template = weaponTemplate;
            ItemLevel = itemLevel;
            RequiredLevel = requiredLevel;
            EquipmentSlotType = Template.EquipmenSlottType;
            DamageValue =  Mathf.Round(Random.Range(weaponTemplate.BaseDamageValue.MinValue, weaponTemplate.BaseDamageValue.MaxValue) * ((100f + (itemLevel - 1) * weaponTemplate.BaseDamageValue.PercentageIncrementPerLevel) / 100f));

        }
        public void Equip(IPlayerCore playerCore)
        {
            //player.Equip(this, EquipmentSlotthis.EquipmentSlotType);
        }
    }*/
}