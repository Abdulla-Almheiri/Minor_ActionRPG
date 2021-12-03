using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName = "new monster template", menuName = "Data/Monster/Monster Template")]
    public class MonsterTemplate : CharacterTemplate, IMonsterTemplate
    {
        [Header("Monster Data")]
        [SerializeField] protected float size = 1;
        [SerializeField] protected float detectRange = 10;
        [SerializeField] protected List<ItemDrop> itemDrop;

        [SerializeField] protected Skill mainAbility;
        [SerializeField] protected Skill secondaryAbility;
        [SerializeField] protected Skill defensiveAbility;
        [SerializeField] protected Skill eliteAbility;
        [SerializeField] protected Skill bossAbility;

        public float Size { get => size; }
        public float DetectRange { get => detectRange; }
        public List<ItemDrop> ItemDrop { get => itemDrop;  }
        public Skill MainAbility { get => mainAbility;  }
        public Skill SecondaryAbility { get => secondaryAbility;  }
        public Skill DefensiveAbility { get => defensiveAbility; }
        public Skill EliteAbility { get => eliteAbility; }
        public Skill BossAbility { get => bossAbility; }

    }
}