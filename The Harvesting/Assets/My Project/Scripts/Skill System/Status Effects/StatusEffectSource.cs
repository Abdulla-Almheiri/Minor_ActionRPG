using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class StatusEffectSource
    {
        public SkillAction SkillAction;
        public Character Character;
        public bool IsEqual(StatusEffectSource statusEffectSource)
        {
            return (statusEffectSource.SkillAction == SkillAction && statusEffectSource.Character == Character);
        }

        public StatusEffectSource(Character character, SkillAction skillAction)
        {
            Character = character;
            SkillAction = skillAction;
        }
    }
}