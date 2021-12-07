using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class EquipmentItem : GameItem
    {
        public int ItemLevel { get; protected set; }
        public new EquipmentItemTemplate Template { get; protected set; }
        public int RequiredLevel { get; protected set; }
        public EquipmentSlotType EquipmentSlotType { get; protected set; }
        public List<ItemStat> Attributes { get; protected set; } = new List<ItemStat>();

        public EquipmentItem(EquipmentItemTemplate template, int requiredLevel, int itemLevel)
        {
            Template = template;
            ItemLevel = itemLevel;
            RequiredLevel = requiredLevel;
            EquipmentSlotType = template.EquipmenSlottType;

        }
        public void Equip(IPlayerCore playerCore)
        {
            //player.Equip(this, EquipmentSlotthis.EquipmentSlotType);
        }
    }
}