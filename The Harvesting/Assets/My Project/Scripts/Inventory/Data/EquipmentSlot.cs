using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
   
    public class EquipmentSlot
    {
        [SerializeField]
        private Image icon;
        private ItemTemplate equipedItem;
        public EquipmentSlotType EquipmentSlotType;

        public bool Equip(ItemTemplate item, IPlayerCore playerCore)
        {
            if(EquipmentSlotType != null && EquipmentSlotType == item.EquipmentSlotType)
            {
                if(equipedItem != null)
                {
                    /*if(!player.AddItemToInventory(equipedItem, 1))
                    {
                        return false;
                    }*/
                }
                equipedItem = item;
                return true;

            }
            return false;
        }
    }
}