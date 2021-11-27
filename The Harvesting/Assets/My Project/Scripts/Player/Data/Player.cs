using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class Player : Character
    {
        private Dictionary<EquipmentSlotType, Item> _equipment;
        private List<ProgressionSkill> _progressionSkills;
        public Player(PlayerTemplate playerTemplate) : base(playerTemplate.CharacterTemplate)
        {
            
        }

    }
}