using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public interface ICharacterMovementController
    {
        NavMeshAgent NavMeshAgent { get; }
        LayerMask Layer { get; }
        void Initialize(CharacterCore characterCore, NavMeshAgent navMeshAgent, LayerMask layer);
    }
}