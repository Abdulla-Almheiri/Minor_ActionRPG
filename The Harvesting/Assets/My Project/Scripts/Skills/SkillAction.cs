using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// Skill Actions are the individual effects of Skills. 
    /// </summary>

    public abstract class SkillAction
    {
        public SkillActionType ActionType;
        public Modifier Modifier;
        public SkillPrefab SkillVFX;

        public abstract void Activate(Character attacker, Character receiver);
    }


}