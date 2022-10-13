using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class QuestTrigger : ScriptableObject
    {
        public abstract bool Evaluate(PlayerCore playerCore);
    }
}