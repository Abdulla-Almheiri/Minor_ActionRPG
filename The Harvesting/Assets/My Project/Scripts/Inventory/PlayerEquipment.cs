using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    public class PlayerEquipment : ScriptableObject
    {
        public EquipmentSlot WeaponSlot;
        public EquipmentSlot OffHandSlot;

        public EquipmentSlot Helm;
        public EquipmentSlot Chest;

        public EquipmentSlot Boots;
        public EquipmentSlot Amulet;
    }
}