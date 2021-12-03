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

        public void Initialize(NavMeshAgent navMeshAgent)
        {
            NavMeshAgent = navMeshAgent ?? GetComponent<NavMeshAgent>();
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