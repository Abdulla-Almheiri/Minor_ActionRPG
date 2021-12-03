using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface ICharacterCore
    {
        IGameManager GameManager { get; }
        ICharacterTemplate Template { get; }
        ICharacterData Data { get; }
        ICharacterAnimationController AnimationController { get; }
        ICharacterCombatController CombatController { get; }
        ICharacterSkillController SkillController { get;  }
        ICharacterMovementController MovementController { get;  }
        ICharacterAIController AIController { get; }
        ICharacterUIController UIController { get; }
        ICharacterItemController ItemController { get; }
        ICharacterSFXController SFXController { get; }
        ICharacterInputController InputController { get; }
    }
}
