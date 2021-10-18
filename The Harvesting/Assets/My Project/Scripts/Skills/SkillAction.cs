using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// Skill Actions are the individual effects of Skills. 
    /// </summary>

    [System.Serializable]
    public  class SkillAction
    {
        public SkillActionType ActionType;
        public Modifier Modifier;
        public SkillPrefab SkillVFX;

        public float Value(Character attacker, Monster receiver)
        {
            if(attacker == null)
            {
                return 0;
            }

            var modifier = attacker.Attributes.Find(x => x.Attribute == Modifier.Attribute);
            if (modifier != null)
            {
                return Modifier.Percentage * modifier.Value / 100f;
            } else
            {
                return 0;
            }

        }
    }


}