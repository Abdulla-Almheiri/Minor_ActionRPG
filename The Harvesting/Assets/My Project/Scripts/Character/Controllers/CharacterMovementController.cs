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

    public abstract class CharacterMovementController : MonoBehaviour
    {
        protected NavMeshAgent _navMeshAgent;

        public NavMeshAgent NavMeshAgent { get => _navMeshAgent; }

        protected void Initialize()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            if (_navMeshAgent == null)
            {
                Debug.Log("No NavMeshAgent component found on CharacterCore: CharacterMovementController.");
                return;
            }

            _navMeshAgent.updateRotation = true;
            _navMeshAgent.autoRepath = true;
        }
        public bool MoveToPoint(Vector3 targetPoint)
        {
           return  _navMeshAgent.SetDestination(targetPoint);
        }

        public bool IsRunning()
        {
            return (_navMeshAgent.remainingDistance >= _navMeshAgent.stoppingDistance);
        }
    }
}