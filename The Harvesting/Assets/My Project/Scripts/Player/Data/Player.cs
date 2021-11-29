using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class Player : Character
    {
        private PlayerCore _playerCore;
        private PlayerTemplate _playerTemplate;

        private Dictionary<EquipmentSlotType, Item> _equipment;
        private Dictionary<object, StatusEffect> _StatusEffects;

        private Skill primaryWeaponSkill;

        private Skill secondaryWeaponSkill;

        public Skill PrimaryWeaponSkill { get => primaryWeaponSkill; }
        public Skill SecondaryWeaponSkill { get => secondaryWeaponSkill; }

        public Player(PlayerCore playerCore, CoreAttributes coreAttributes, PlayerTemplate playerTemplate) : base(playerCore, coreAttributes, playerTemplate)
        {
            _playerCore = playerCore;
            _playerTemplate = playerTemplate;

            UpdateAbilities();


        }

        public bool Equip(Item item)
        {
            return false;
        }

        public void LevelUp(int newLevel)
        {
            var attribute = _attributes[_coreAttributes.Level];

            if (newLevel <= attribute.FinalValue())
            {
                return;
            }

            attribute.BaseAdd = newLevel;
        }

        protected void UpdateAbilities()
        {
            foreach (ProgressionSkill progressionSkill in _playerTemplate.Progression)
            {
                if(progressionSkill.Level <= _attributes[_coreAttributes.Level].FinalValue())
                {
                    _abilities.Add(progressionSkill.Skill);
                }
            }
        }
    }
}