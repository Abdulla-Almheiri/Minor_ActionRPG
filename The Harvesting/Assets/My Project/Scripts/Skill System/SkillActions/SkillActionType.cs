using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{ 
   // [CreateAssetMenu(fileName ="new skill action type", menuName ="Data/Skills/Skill Action Type")]
    public class SkillActionType : ScriptableObject
    {
        public bool Continuous;
        public bool StatusEffect;
        public bool ResourceDrain;
    }
}