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
        public PlayerCore PlayerCore;
        public Animator Animator;
        private PlayerCombatController combatController;
        private PlayerSkillController skillController;
        private PlayerMovementController movementController;

        private NavMeshAgent navMeshAgent;

        void Start()
        {
            Animator = GetComponentInChildren<Animator>();
            PlayerCore = GetComponent<PlayerCore>();
            combatController = GetComponent<PlayerCombatController>();
            skillController = GetComponent<PlayerSkillController>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            movementController = GetComponent<PlayerMovementController>();
        }

        void Update()
        {
            if(movementController.IsRunning())
            {
                Animator.SetBool("Running", true);
            } else
            {
                Animator.SetBool("Running", false);
            }
        }
    }
}