using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class MonsterInputController : CharacterInputController, IMonsterInputController
    {
        public new IMonsterCore Core { get; protected set; }

        public void Initialize(IMonsterCore core, InputKeyData inputKeyData)
        {
            Core = core;
            base.Initialize(core, inputKeyData);

        }
    }
}
