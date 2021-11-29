using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(PlayerCombatController))]

    public class PlayerAnimationController : CharacterAnimationController
    {
        private PlayerCore _playerCore;
        private PlayerCombatController combatController;
        private PlayerSkillController skillController;
        private PlayerMovementController _playerMovementController;
        

        void Awake()
        {
            Initialize(null);
        }

        void Update()
        {
            HandleRunningAnimation();
        }

        protected override void Initialize(Animator animator)
        {
            base.Initialize(animator);

            _playerCore = GetComponent<PlayerCore>();
            combatController = GetComponent<PlayerCombatController>();
            skillController = GetComponent<PlayerSkillController>();
            _playerMovementController = GetComponent<PlayerMovementController>();
            _layer = _playerMovementController.Layer;
        }

        protected override void HandleRunningAnimation()
        {
            if (_playerMovementController.IsRunning())
            {
                Animator.SetBool("Running", true);
            }
            else
            {
                Animator.SetBool("Running", false);
            }
        }

        public void PlaySkillAnimation(Skill skill)
        {
            Animator.SetTrigger(skill.PlayerAnimation.AnimationHash());
        }
    }
}