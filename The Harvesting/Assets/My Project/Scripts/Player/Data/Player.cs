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

        protected Skill _primaryWeaponSkill;
        protected Skill _secondaryWeaponSkill;
        private List<Skill> _abilities = new List<Skill>();

        public List<Skill> Abilities { get => _abilities; }

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
            if(newLevel <= _level.FinalValue())
            {
                return;
            }

            _level.BaseAdd = newLevel;
        }

        protected void UpdateAbilities()
        {
            foreach (ProgressionSkill progressionSkill in _playerTemplate.Progression)
            {
                if(progressionSkill.Level <= _level.FinalValue())
                {
                    _abilities.Add(progressionSkill.Skill);
                }
            }
        }
    }
}