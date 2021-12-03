using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface ICharacterSkillController 
    {
        ICharacterCore Core { get; }
        CombatSettings CombatSettings { get; }
        List<SkillSpawnLocationData> SkillSpawnLocations { get; }
        bool ActivateSkill(Skill skill, Vector3 direction);
        float SkillRecharge(Skill skill, out float seconds);
        void Initialize(ICharacterCore core, CombatSettings combatSettings, List<SkillSpawnLocationData> skillSpawnLocations);
    }
}