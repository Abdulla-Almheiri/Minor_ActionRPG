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
        public bool IsDead = false;

        private bool[] array;
        public bool[] GetArray()
        {
            if(array!= null)
            {
                array = new bool[7];
            }

            array[0] = CanMove;
            array[1] = CanInteract;
            array[2] = CanAttack;
            array[3] = CanCast;
            array[4] = CanBlock;
            array[5] = CanTakeDamage;
            array[6] = CanBeHealed;

            return array;
        }

        public void PrintDebugValues()
        {
            Debug.Log("Is Dead : " + IsDead);
            Debug.Log("Can Move  : " + CanMove);
            Debug.Log("Can Interact  : " + CanInteract);
            Debug.Log("Can attack : " + CanAttack);
            Debug.Log("Can Cast  : " + CanCast);
            Debug.Log("Can Block  : " + CanBlock);
            Debug.Log("Can Take Damage  : " + CanTakeDamage);
            Debug.Log("Can Be Healed  : " + CanBeHealed);

        }
    }
}