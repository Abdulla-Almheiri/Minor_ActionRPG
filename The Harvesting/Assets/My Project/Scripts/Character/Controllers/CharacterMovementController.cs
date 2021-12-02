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
    [RequireComponent(typeof(CharacterCombatController))]

    public abstract class CharacterMovementController : MonoBehaviour, ICharacterMovementController
    {
        public ICharacterCore Core { get; protected set; }
        public NavMeshAgent NavMeshAgent { get; protected set; }

        protected void Initialize()
        {
            NavMeshAgent = GetComponent<NavMeshAgent>();
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
           return  NavMeshAgent.SetDestination(targetPoint);
        }

        public bool IsRunning()
        {
            return (NavMeshAgent.remainingDistance >= NavMeshAgent.stoppingDistance);
        }
    }
}