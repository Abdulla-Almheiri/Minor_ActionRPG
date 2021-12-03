using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerCombatController : CharacterCombatController, IPlayerCombatController
    {
        public new IPlayerCore Core { get; protected set; }

        public void Initialize(IPlayerCore core)
        {
            Core = core;
            base.Initialize(core);
        }

    }
}