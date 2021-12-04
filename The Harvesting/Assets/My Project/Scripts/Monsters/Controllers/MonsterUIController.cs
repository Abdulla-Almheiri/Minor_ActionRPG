using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class MonsterUIController : CharacterUIController, IMonsterUIController
    {
        public new IMonsterCore Core { get; protected set; }

        public void Initialize(IMonsterCore core)
        {
            Core = core;
            base.Initialize(core);
        }
    }
}