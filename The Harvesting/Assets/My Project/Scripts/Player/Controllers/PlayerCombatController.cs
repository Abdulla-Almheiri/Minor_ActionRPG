using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerCombatController : CharacterCombatController
    {
        public IPlayerCore Core { get; protected set; }
        protected override void Start()
        {
            base.Start();
            Initialize(null);
        }
        public void Initialize(PlayerCore playerCore)
        {
            Core = playerCore ?? GetComponent<PlayerCore>();
        }

    }
}