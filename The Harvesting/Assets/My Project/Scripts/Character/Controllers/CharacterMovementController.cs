using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

namespace Harvesting
{
    /// <summary>
    /// CharacterMovementController Monobehavior. Controlls Character movement. Requires NavMeshAgent component.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]

    public abstract class CharacterMovementController : MonoBehaviour, ICharacterMovementController
    {
        public ICharacterCore Core { get; protected set; }
        public NavMeshAgent NavMeshAgent { get; protected set; }
        public Transform Transform { get; protected set; }

        protected Vector3 currentDestination;

        public void Initialize(ICharacterCore core, NavMeshAgent navMeshAgent, Transform transform)
        {
            Core = core;
            NavMeshAgent = navMeshAgent;
            Transform = transform;

            if (NavMeshAgent == null)
            {
                Debug.Log("No NavMeshAgent component found on CharacterCore: CharacterMovementController.");
                return;
            }

            NavMeshAgent.updateRotation = true;
            NavMeshAgent.autoRepath = true;
        }
        public bool MoveToPoint(Vector3 targetPoint)
        {
            
            if (Core.CombatController.CanMove() == false)
            {
                return false;
            }

            
            NavMeshAgent.isStopped = false;
            var navMeshMove = NavMeshAgent.SetDestination(targetPoint);
            if(navMeshMove == true)
            {
                currentDestination = NavMeshAgent.destination;
                Core.AnimationController.Animator.SetBool("Running", true);
            }
            return navMeshMove;
        }

        public bool IsRunning()
        {
            return (NavMeshAgent.remainingDistance >= NavMeshAgent.stoppingDistance) && Core.CombatController.CanMove();
        }
        private void Update()
        {

        }
        public void StopMoving()
        {
            Core.AnimationController.Animator.SetBool("Running", false);
            NavMeshAgent.isStopped = true;
        }

        public bool MoveToCharacter(ICharacterCore character)
        {

            if (character == null || Core.CombatController.IsWithinMeleeRange(character))
            {
                return false;
            }
            return MoveToPoint(character.MovementController.Transform.position);
        }
    }
}