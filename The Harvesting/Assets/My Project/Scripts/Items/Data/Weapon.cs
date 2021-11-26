using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class Weapon : Item
    {
        public int ItemLevel = 0;
        public int RequiredLevel = 1;
        public EquipmentSlotType EquipmentSlotType;

        public List<ItemStat> Attributes = new List<ItemStat>();

        private WeaponTemplate _weaponTemplate;
        public Weapon(WeaponTemplate weaponTemplate)
        {
            _weaponTemplate = weaponTemplate;
            Icon = _weaponTemplate.Icon;
        }
        public override void Interact(PlayerCore playerCore)
        {

        }

        public void Equip(PlayerData player)
        {
            //player.Equip(this, EquipmentSlotthis.EquipmentSlotType);
        }

        public override ItemTemplate Template()
        {
            return _weaponTemplate;
        }
    }
}