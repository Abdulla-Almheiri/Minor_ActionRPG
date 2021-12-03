using System.Collections;
using System.Collections.Generic;


namespace Harvesting
{
    public interface IPlayerMovementController : ICharacterMovementController
    {
        IPlayerCore Core { get; }
        void MoveToMousePosition();
        void Initialize(IPlayerCore playerCore, UnityEngine.AI.NavMeshAgent navMeshAgent);
    }
}