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
        Transform Transform { get; }
        bool IsRunning();
        bool MoveToPoint(Vector3 targetPoint);
        bool MoveToCharacter(ICharacterCore character);
        void StopMoving();

        void Initialize(ICharacterCore core, NavMeshAgent navMeshAgent, Transform transform);
    }
}