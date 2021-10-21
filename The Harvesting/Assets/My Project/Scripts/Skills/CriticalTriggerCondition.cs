using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class CriticalTriggerCondition : SkillActionTriggerCondition
    {
        public override bool Evaluate(SkillAction action, CharacterData performer)
        {
            return true;
        }
    }
}