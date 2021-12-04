using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class MonsterAIController : CharacterAIController, IMonsterAIController
    {
        public new IMonsterCore Core { get; protected set; }
        public void Initialize(IMonsterCore core)
        {
            Core = core;
            base.Initialize(core);
        }
    }
}