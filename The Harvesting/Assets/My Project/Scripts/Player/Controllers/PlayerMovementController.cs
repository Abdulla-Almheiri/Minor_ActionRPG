using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerMovementController : MonoBehaviour
    {
        
        private PlayerCore playerCore;
        private PlayerCombatController combatController;
        private PlayerSkillController skillController;
        private PlayerAnimationController animationController;
        private Animator animator;
        private NavMeshAgent navAgent;
        public LayerMask Layer;
        void Start()
        {
            navAgent = gameObject.GetComponent<NavMeshAgent>();
            navAgent.updateRotation = true;
            navAgent.autoRepath = true;
            combatController = GetComponent<PlayerCombatController>();
            skillController = GetComponent<PlayerSkillController>();
            animationController = GetComponent<PlayerAnimationController>();

            animator = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            MoveToMouse();
        }

        public void MoveToMouse()
        {
            var currentState = combatController.CurrentCharacterState();
            //currentState.PrintDebugValues();
            if(!currentState.CanMove)
            {
                return;
            }



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
    }
}