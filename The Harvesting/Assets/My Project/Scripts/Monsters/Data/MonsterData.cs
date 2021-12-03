using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

namespace Harvesting
{
    public class MonsterData : IMonsterData
    {
        public float Size { get; protected set; } = 1f;
        public float DetectRange { get; protected set; } = 10f;
        //FIX ITEM DROP TO CLONE THIS LIST FROM TEMPLATE
        public List<ItemDrop> ItemDrop { get; protected set; } = new List<ItemDrop>();

        public Skill MainAbility { get; protected set; }
        public Skill SecondaryAbility { get; protected set; }
        public Skill DefensiveAbility { get; protected set; }

        public Skill EliteAbility { get; protected set; }

        public Skill BossAbility { get; protected set; }

        public void Initialize(IMonsterTemplate template)
        {
            Size = template.Size;
            DetectRange = template.DetectRange;
            MainAbility = template.MainAbility;
            SecondaryAbility = template.SecondaryAbility;
            DefensiveAbility = template.DefensiveAbility;
        }
    }

}