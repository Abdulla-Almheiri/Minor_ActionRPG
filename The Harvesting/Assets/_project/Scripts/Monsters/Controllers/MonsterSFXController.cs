using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class MonsterSFXController : CharacterSFXController, IMonsterSFXController
    {
        public new IMonsterCore Core { get; protected set; }

        public void Initialize(IMonsterCore core)
        {
            Core = core;
            base.Initialize(Core);
        }
    }
}
