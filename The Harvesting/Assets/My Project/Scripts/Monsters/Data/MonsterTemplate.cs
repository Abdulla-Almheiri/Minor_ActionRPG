using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName = "new monster template", menuName = "Data/Monster/Monster Template")]
    public class MonsterTemplate : ScriptableObject
    {
        [Header("Monster Data")]
        public float Size = 1;
        public float DetectRange = 10;
        public List<ItemDrop> itemDrop;
        public CharacterTemplate CharacterTemplate;
    }
}