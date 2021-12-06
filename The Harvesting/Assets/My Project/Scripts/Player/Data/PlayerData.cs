using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class PlayerData 
    {

        public Skill PrimaryWeaponSkill { get; protected set; }

        public Skill SecondaryWeaponSkill { get; protected set; }

        public Dictionary<EquipmentSlotType, GameItem> Equipment { get; protected set; } = new Dictionary<EquipmentSlotType, GameItem>();

        public Inventory Inventory { get; protected set; }

        public PlayerData(Inventory inventory, Dictionary<EquipmentSlotType, GameItem> equipment)
        {
            Inventory = inventory;
            Equipment = equipment;
        }
    }
}