using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// CharacterCore class. This is used as the Core for the player and monsters. All necessary components will be added automatically.
    /// </summary>
    public abstract class CharacterCore : Core
    {
        protected CoreAttributes _coreAttributes;
        private CharacterTemplate _characterTemplate;

        public CharacterAnimationController AnimationController { get => animationController;  }
        public CharacterCombatController CombatController { get => combatController;  }
        public CharacterSkillController SkillController { get => skillController;  }
        public CharacterMovementController MovementController { get => movementController;  }

        private CharacterAnimationController animationController;
        private CharacterCombatController combatController;
        private CharacterSkillController skillController;
        private CharacterMovementController movementController;

        void Start()
        {
            Initialize();
        }


        void Update()
        {

        }

        private void Initialize()
        {
            animationController = GetComponent<CharacterAnimationController>();
            combatController = GetComponent<CharacterCombatController>();
            skillController = GetComponent<CharacterSkillController>();
            movementController = GetComponent<CharacterMovementController>();

        }
    }
}