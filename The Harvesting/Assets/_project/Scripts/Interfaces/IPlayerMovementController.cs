using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayerMovementController : ICharacterMovementController
    {
        new IPlayerCore Core { get; }
        void MoveToMousePosition();
        void Initialize(IPlayerCore playerCore, NavMeshAgent navMeshAgent, Transform transform);
    }
}