using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerCombatController : CharacterCombatController, IPlayerCombatController
    {
        [SerializeField] private MonsterDetectorScript _monsterDetector;
        public new IPlayerCore Core { get; protected set; }

        public void Initialize(IPlayerCore core)
        {
            Core = core;

            _monsterDetector.Initialize(Core);
            base.Initialize(core);
            
        }

    }
}