using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IWeaponItem : IGameItem
    {
        int ItemLevel { get; }
        int RequiredLevel { get; }
        EquipmentSlotType EquipmentSlotType { get; }
        public float DamageValue { get; }
        public List<ItemStat> Attributes { get; }
    }
}