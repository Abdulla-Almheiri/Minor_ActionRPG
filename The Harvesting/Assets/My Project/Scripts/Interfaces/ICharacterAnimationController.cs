using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public interface ICharacterAnimationController
    {
        ICharacterCore Core { get; }
        Animator Animator { get; }
        ICharacterMovementController MovementController {get; }
        void Initialize(ICharacterCore core, Animator animator);

        void HandleRunningAnimation();
    }
}