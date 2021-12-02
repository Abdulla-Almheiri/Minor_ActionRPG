using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class PlayerSkillData
    {
        private PlayerCore _playerCore;
        private PlayerTemplate _playerTemplate;

        protected List<Skill> _abilities = new List<Skill>();
        public List<Skill> Abilities { get => _abilities; }

        

        private Skill primaryWeaponSkill;

        private Skill secondaryWeaponSkill;

        public Skill PrimaryWeaponSkill { get => primaryWeaponSkill; }
        public Skill SecondaryWeaponSkill { get => secondaryWeaponSkill; }
        public PlayerTemplate PlayerTemplate { get => _playerTemplate; set => _playerTemplate = value; }

        public PlayerSkillData( CoreAttributesTemplate coreAttributes, PlayerTemplate playerTemplate)
        {
            PlayerTemplate = playerTemplate;
        }

    }
}