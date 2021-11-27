using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerMovementController : MonoBehaviour
    {
        
        private PlayerCore _playerCore;
        private PlayerCombatController combatController;
        private PlayerSkillController skillController;
        private PlayerAnimationController animationController;
        private Animator animator;
        private NavMeshAgent navAgent;
        public LayerMask Layer;
        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            MoveToMouse();
        }

        public void MoveToMouse()
        {
            var currentState = _playerCore?.PlayerCombatController?.CurrentCharacterState();

            //currentState.PrintDebugValues();
           /* if(!currentState.CanMove)
            {
                return;
            }*/



            if (Input.GetMouseButton(0))
            {
                //navAgent.isStopped = false;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayHit;

                if (Physics.Raycast(ray, out rayHit, Layer))
                {
                    navAgent.SetDestination(rayHit.point);
                }
            }

            


        }

        public bool IsRunning()
        {
            return (navAgent.remainingDistance >= navAgent.stoppingDistance);
        }

        private void Initialize()
        {
            _playerCore = GetComponent<PlayerCore>();
            navAgent = gameObject.GetComponent<NavMeshAgent>();
            navAgent.updateRotation = true;
            navAgent.autoRepath = true;
            combatController = _playerCore.PlayerCombatController;
            skillController = GetComponent<PlayerSkillController>();
            animationController = GetComponent<PlayerAnimationController>();

            animator = GetComponentInChildren<Animator>();
        }
    }
}