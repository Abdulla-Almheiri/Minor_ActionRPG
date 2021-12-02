using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayerData : ICharacterData
    {
        public List<Skill> Abilities { get; }
        public Skill PrimaryWeaponSkill { get; }
        public Skill SecondaryWeaponSkill { get; }

        public Dictionary<EquipmentSlotType, Item> Equipment { get; }
        public Inventory Inventory { get; }

    }
}