using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class PlayerData : CharacterData, IPlayerData
    {
        public List<Skill> Abilities { get; protected set; } = new List<Skill>();

        public Skill PrimaryWeaponSkill { get; protected set; }

        public Skill SecondaryWeaponSkill { get; protected set; }

        public Dictionary<EquipmentSlotType, Item> Equipment { get; protected set; } = new Dictionary<EquipmentSlotType, Item>();

        public Inventory Inventory { get; protected set; }

        public void Initialize(ICharacterCore core, IPlayerTemplate playerTemplate)
        {
            //FIX HERE. INITIALIZE ABILITIES
            foreach(ProgressionSkill skill in playerTemplate.SkillProgression)
            {
                Abilities.Add(skill.Skill);
            }
        }
    }
}