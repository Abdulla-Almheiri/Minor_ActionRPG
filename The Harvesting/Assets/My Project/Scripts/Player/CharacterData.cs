using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{ 
    /// <summary>
    /// Base class for Player and Monster classes.
    /// </summary>

    public abstract class CharacterData: ScriptableObject
    {

        public List<Modifier> BaseAttributes;
        private CharacterState combatState;
        public abstract void Initialize();
        public abstract void UseItem(Item item);
        public abstract void ActivateSkill(SkillAction skill);
        public abstract void ReceiveSkillAction(SkillAction skill);

    }
}