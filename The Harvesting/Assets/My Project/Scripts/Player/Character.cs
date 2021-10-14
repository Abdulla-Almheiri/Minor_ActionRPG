using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{ 
    /// <summary>
    /// Base class for Player and Monster classes.
    /// </summary>
    public abstract class Character : ScriptableObject
    {

        public List<Attribute> Attributes;
        public abstract void Initialize();
        public abstract void UseItem(Item item);
        public abstract void PerformSkillAction(SkillAction skillAction);
        public abstract void ReceiveSkillAction(SkillAction skillAction);
    }
}