using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonsterCombatController : ICharacterCombatController
    {
        new IMonsterCore Core { get; }
        void Initialize(IMonsterCore core);
    }
}