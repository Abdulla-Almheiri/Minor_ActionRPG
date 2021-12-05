using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new monster AI", menuName ="Data/Monster/AI/Monster AI")]
    public class MonsterAI : ScriptableObject
    {
        public WeightedBool AttackInMelee;
        public WeightedBool RunWhenLowOnHealth;
        public WeightedBool CastSupportSpells;
        public WeightedBool AttackFromRange;

    }
}