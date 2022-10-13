using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayerData : ICharacterData
    {
        public Skill PrimaryWeaponSkill { get; }
        public Skill SecondaryWeaponSkill { get; }

        public Dictionary<EquipmentSlotType, GameItem> Equipment { get; }
        public Inventory Inventory { get; }

    }
}