using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting {
    public class MonsterSkillController : CharacterSkillController, IMonsterSkillController
    {
        public new IMonsterCore  Core { get; protected set; }

        public void Initialize(IMonsterCore core, CombatSettings combatSettings, List<SkillSpawnLocationData> skillSpawnLocations)
        {
            Core = core;
            base.Initialize(core, combatSettings, skillSpawnLocations);
        }
    }
}