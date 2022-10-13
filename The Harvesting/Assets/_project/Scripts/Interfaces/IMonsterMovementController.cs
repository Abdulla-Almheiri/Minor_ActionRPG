using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public interface IMonsterMovementController : ICharacterMovementController
    {
        new IMonsterCore Core { get; }
        void Initialize(IMonsterCore core, NavMeshAgent navMeshAgent, Transform transform);
    }
}