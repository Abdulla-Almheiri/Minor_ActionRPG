using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayerSkillController : ICharacterSkillController
    {
        List<Skill> Abilities { get; }
        new IPlayerCore Core { get; }
        Skill PrimaryWeaponSkill { get; }
        Skill SecondaryWeaponSkill { get; }

        void Initialize(IPlayerCore playerCore, CombatSettings combatSettings, List<SkillSpawnLocationData> skillSpawnLocations);
    }
}