using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class EnemyKillQuestTrigger : QuestTrigger
    {
        public CharacterTemplate Enemy;
        public int KillCount = 1;
        public override bool Evaluate(PlayerCore playerCore)
        {
            throw new System.NotImplementedException();
        }
    }
}
