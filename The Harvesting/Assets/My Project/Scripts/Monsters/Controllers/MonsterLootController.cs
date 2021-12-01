using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting {
    [RequireComponent(typeof(MonsterAnimationController))]
    public class MonsterLootController : MonoBehaviour
    {
        protected MonsterCore _monsterCore;


        public List<GameObject> SpawnLoot(List<ItemDrop> additionalLoot = null)
        {
            List<GameObject> listOfSpawnedItemPrefabs = new List<GameObject>();

            return listOfSpawnedItemPrefabs;
        }
    }
}
