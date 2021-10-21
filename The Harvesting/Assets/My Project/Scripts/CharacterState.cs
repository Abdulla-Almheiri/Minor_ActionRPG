using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new character state", menuName ="Data/Character/Character State")]
    public class CharacterState : ScriptableObject
    {
        public bool CanMove = true;
        public bool CanInteract = true;
        public bool CanAttack = true;
        public bool CanCast = true;
        public bool CanBlock = true;
        public bool CanTakeDamage = true;
        public bool CanBeHealed = true;
    }
}