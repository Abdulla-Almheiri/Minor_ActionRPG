using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerAnimationController : MonoBehaviour
    {
        private PlayerCore _playerCore;
        private Animator _animator;
        private PlayerCombatController combatController;
        private PlayerSkillController skillController;
        private PlayerMovementController movementController;

        private NavMeshAgent navMeshAgent;

        public Animator Animator { get => _animator; }

        void Awake()
        {

            Initialize();
        }

        void Update()
        {
            HandleRunningAnimation();
        }

        private void Initialize()
        {
            _animator = GetComponentInChildren<Animator>();
            _playerCore = GetComponent<PlayerCore>();
            combatController = GetComponent<PlayerCombatController>();
            skillController = GetComponent<PlayerSkillController>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            movementController = GetComponent<PlayerMovementController>();
        }

        private void HandleRunningAnimation()
        {
            if (movementController.IsRunning())
            {
                Animator.SetBool("Running", true);
            }
            else
            {
                Animator.SetBool("Running", false);
            }
        }
    }
}