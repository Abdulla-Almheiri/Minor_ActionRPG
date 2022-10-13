using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class PlayerItemData
    {
        private PlayerCore _playerCore;
        private Dictionary<EquipmentSlotType, GameItem> _equipment = new Dictionary<EquipmentSlotType, GameItem>();
        private Inventory _inventory;

        public PlayerItemData()
        {
            _inventory = new Inventory();
        }
        public bool Equip(EquipmentSlot slot, GameItem item)
        {
            return false;
        }

        public bool Unequip(EquipmentSlot slot)
        {
            return false;
        }
    }
}