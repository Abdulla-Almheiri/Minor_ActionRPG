using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new monster AI", menuName ="Data/Monster/AI/Monster AI")]
    public class MonsterAI : ScriptableObject
    {
        public float DetectRange = 10f;
        public float MeleeRange = 2f;
        /*public WeightedBool Chase;
        public WeightedBool Avoid;
        public WeightedBool AttackFromRange;
        public WeightedBool RunWhenLowOnHealth;*/

        public void HandleAI()
        {

        }

        public Vector3 CalculatedDestination(PlayerCore playerCore, MonsterCore monsterCore)
        {
            if(Distance(playerCore, monsterCore) <= DetectRange)
            {
                return playerCore.transform.position;
            } else
            {
                return monsterCore.transform.position;
            }
                
        }

        private float Distance(PlayerCore playerCore, MonsterCore monsterCore)
        {
            return Vector3.Distance(playerCore.transform.position, monsterCore.transform.position);
        }

        public bool InMeleeRange(PlayerCore playerCore, MonsterCore monsterCore)
        {
            return Distance(playerCore, monsterCore) <= MeleeRange;
        }
    }
}