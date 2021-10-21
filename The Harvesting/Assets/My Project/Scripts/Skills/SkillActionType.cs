using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{ 
   // [CreateAssetMenu(fileName ="new skill action type", menuName ="Data/Skills/Skill Action Type")]
    public abstract class SkillActionType : ScriptableObject
    {
        public bool Damage;
        public bool Heal;
        public bool Enhancement;
        public bool Hinderance;
       
        public abstract void TriggerSkillActionType();
    }
}