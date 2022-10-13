using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [System.Serializable]
    public class SkillActionTrigger
    {
        public SkillActionTriggerCondition Condition;
        [Range(0f,100f)]
        public float Chance;
    }
}