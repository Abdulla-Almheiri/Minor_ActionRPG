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

        // Update is called once per frame
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

        public void TryPlayAnimation(MyAnimation animation)
        {
            Animator.Play(animation.AnimationHash());
        }

        private void PlayAnimation(MyAnimation animation)
        {
            if (animation != null)
            {
                Animator.Play(animation.AnimationHash());
            }
        }

        public void FreezeAnimation()
        {
            Animator.speed = 0;
        }

        public void UnfreezeAnimation()
        {
            Animator.speed = 1;
        }
    }
}