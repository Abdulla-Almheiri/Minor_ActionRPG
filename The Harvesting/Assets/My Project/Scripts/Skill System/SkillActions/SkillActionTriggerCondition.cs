using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    public abstract class SkillActionTriggerCondition : ScriptableObject
    {

        public abstract bool Evaluate(SkillAction action, ICharacterCore performer);
    }
}