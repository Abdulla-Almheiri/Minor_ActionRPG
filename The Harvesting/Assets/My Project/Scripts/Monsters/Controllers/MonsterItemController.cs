using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting {
    [RequireComponent(typeof(MonsterAnimationController))]
    public class MonsterItemController : CharacterItemController, IMonsterItemController
    {
        public new IMonsterCore Core { get; protected set; }


        public void SpawnLoot()
        {
          
        }
    }
}
