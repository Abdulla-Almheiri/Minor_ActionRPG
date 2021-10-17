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

        public void Activate(Character attacker, Character receiver)
        {

        }
    }


}