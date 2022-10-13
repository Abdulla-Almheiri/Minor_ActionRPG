using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonsterData 
    {
        float Size { get; }
        float DetectRange { get; }
        //FIX ITEM DROP TO CLONE THIS LIST FROM TEMPLATE
        List<ItemDrop> ItemDrop { get; }

        Skill MainAbility { get; }
        Skill SecondaryAbility { get; }
        Skill DefensiveAbility { get; }
        Skill EliteAbility { get; }
        Skill BossAbility { get; }
        public void Initialize(IMonsterTemplate template);
    }
}