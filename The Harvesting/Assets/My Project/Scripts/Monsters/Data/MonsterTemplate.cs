using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName = "new monster template", menuName = "Data/Monster/Monster Template")]
    public class MonsterTemplate : CharacterTemplate
    {
        [Header("Monster Data")]
        public float Size = 1;
        public float DetectRange = 10;
        public List<ItemDrop> itemDrop;

        public Skill MainAbility;
        public Skill SecondaryAbility;
        public Skill DefensiveAbility;
    }
}