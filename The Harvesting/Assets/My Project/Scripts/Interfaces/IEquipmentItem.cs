using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IEquipmentItem : IGameItem
    {
        int ItemLevel { get; }
        public new EquipmentItemTemplate Template { get; }
        int RequiredLevel { get; }
        public EquipmentSlotType EquipmentSlotType { get; }
        public List<ItemStat> Attributes { get; }

        void Equip(IPlayerCore playerCore);

    }
}
