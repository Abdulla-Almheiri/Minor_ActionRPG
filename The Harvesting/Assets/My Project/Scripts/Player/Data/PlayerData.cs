using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class PlayerData 
    {

        public Skill PrimaryWeaponSkill { get; protected set; }

        public Skill SecondaryWeaponSkill { get; protected set; }

        public Dictionary<EquipmentSlotType, Item> Equipment { get; protected set; } = new Dictionary<EquipmentSlotType, Item>();

        public Inventory Inventory { get; protected set; }

        public PlayerData(Inventory inventory, Dictionary<EquipmentSlotType, Item> equipment)
        {
            Inventory = inventory;
            Equipment = equipment;
        }
    }
}