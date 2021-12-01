using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public interface ICharacterAnimationController
    {
        CharacterCore CharacterCore { get; }
        Animator Animator { get; }
        CharacterMovementController MovementController {get; }
        void Initialize(CharacterCore characterCore, Animator animator);

        void HandleRunningAnimation();
    }
}