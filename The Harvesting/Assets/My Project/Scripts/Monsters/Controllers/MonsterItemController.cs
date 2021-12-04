using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting {
    [RequireComponent(typeof(MonsterAnimationController))]
    public class MonsterItemController : CharacterItemController, IMonsterItemController
    {
        public new IMonsterCore Core { get; protected set; }

        public void Initialize(IMonsterCore core)
        {
            Core = core;
            base.Initialize(core);
        }

        public void SpawnLoot()
        {
          
        }
    }
}
