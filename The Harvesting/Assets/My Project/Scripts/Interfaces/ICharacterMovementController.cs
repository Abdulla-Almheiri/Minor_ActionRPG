using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public interface ICharacterMovementController
    {
        ICharacterCore Core { get; }
        NavMeshAgent NavMeshAgent { get; }
        bool IsRunning();
        bool MoveToPoint(Vector3 targetPoint);
        void Initialize(NavMeshAgent navMeshAgent);
    }
}