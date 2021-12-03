using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class MonsterCombatController : CharacterCombatController, IMonsterCombatController
    {
        new public IMonsterCore Core { get; protected set; }

    }
}