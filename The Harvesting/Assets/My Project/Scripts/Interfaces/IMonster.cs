using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonster : ICharacterCombatController, ILootDropper, IExperiencePointsGiver
    {
        float Level { get; }
        float Size { get; }
        float DetectRange { get; }
        MonsterAI MonsterAI { get; }
    }
}