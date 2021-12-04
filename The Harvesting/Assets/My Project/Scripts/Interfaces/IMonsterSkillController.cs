using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonsterSkillController : ICharacterSkillController
    {
        new IMonsterCore Core { get; }
        void Initialize(IMonsterCore core, CombatSettings combatSettings, List<SkillSpawnLocationData> skillSpawnLocations);
    }
}