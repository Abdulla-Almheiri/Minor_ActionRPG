using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName = "Triggers List", menuName = "Data/Skills/Triggers List")]
    public class TriggersList : ScriptableObject
    {
        public List<SkillTriggerCondition> TriggerConditions;
    }
}