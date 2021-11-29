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
        [SerializeField] protected CoreAttributes _coreAttributes;
        [SerializeField] private CharacterTemplate _characterTemplate;

        public CharacterTemplate BaseCharacter;


        //Combat Attributes



        //


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

        /// <summary>
        /// Caching the controllers. To be called in the Start() callback.
        /// </summary>
        private void Initialize()
        {
            animationController = GetComponent<CharacterAnimationController>();
            combatController = GetComponent<CharacterCombatController>();
            skillController = GetComponent<CharacterSkillController>();
            movementController = GetComponent<CharacterMovementController>();

        }
    }
}