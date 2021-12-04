using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public interface ICharacterCore
    {
        IGameManager GameManager { get; }
        ICharacterTemplate Template { get; }
        CharacterData CharacterData { get; }
        ICharacterAnimationController AnimationController { get; }
        ICharacterCombatController CombatController { get; }
        ICharacterSkillController SkillController { get;  }
        ICharacterMovementController MovementController { get;  }
        ICharacterAIController AIController { get; }
        ICharacterUIController UIController { get; }
        ICharacterItemController ItemController { get; }
        ICharacterSFXController SFXController { get; }
        ICharacterInputController InputController { get; }
        void Initialize(IGameManager gameManager, ICharacterTemplate template, Animator animator, NavMeshAgent navMeshAgent, Transform transform, List<SkillSpawnLocationData> skillSpawnLocations);
    }
}
