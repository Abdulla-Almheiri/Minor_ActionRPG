using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerCombatController : CharacterCombatController
    {
        private PlayerCore _playerCore;
        private Player _player;

        protected override void Start()
        {
            base.Start();
            Initialize(null);
        }
        public void Initialize(PlayerCore playerCore)
        {
            _playerCore = playerCore ?? GetComponent<PlayerCore>();
        }
    }
}