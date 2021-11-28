using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class Player : Character
    {
        private PlayerCore _playerCore;

        private Dictionary<EquipmentSlotType, Item> _equipment;
        private List<ProgressionSkill> _progressionSkills;
        private Dictionary<object, StatusEffect> _StatusEffects;
        public Player(PlayerCore playerCore, CoreAttributes coreAttributes, PlayerTemplate playerTemplate) : base(null, coreAttributes, playerTemplate)
        {
            
            BoundHealth();
            BoundMana();
        }

    }
}