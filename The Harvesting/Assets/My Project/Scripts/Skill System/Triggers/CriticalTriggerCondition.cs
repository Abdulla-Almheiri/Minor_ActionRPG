using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new critical trigger", menuName ="Data/Skills/Trigger/Critical Trigger")]
    public class CriticalTriggerCondition : SkillActionTriggerCondition
    {
        public override bool Evaluate(SkillAction action, ICharacterCore performer)
        {
            return true;
        }
    }
}