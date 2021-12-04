using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class MonsterCombatController : CharacterCombatController, IMonsterCombatController
    {
        new public IMonsterCore Core { get; protected set; }

        public void Initialize(IMonsterCore core)
        {
            Core = core;
            base.Initialize(core);
        }
    }
}