using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    public abstract class SkillTriggerCondition : ScriptableObject
    {
        public abstract bool Evaluate(ICharacterCore character);
    }
}