using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonsterTemplate : ICharacterTemplate
    {
        float Size { get; }
        float DetectRange { get; }
        List<ItemDrop> ItemDrop { get; }
        Skill MainAbility { get; }
        Skill SecondaryAbility { get; }
        Skill DefensiveAbility { get; }
        Skill EliteAbility { get; }
        Skill BossAbility { get; }
    }
}