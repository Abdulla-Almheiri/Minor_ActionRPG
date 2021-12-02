using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface ICharacterCore
    {
        IGameManager GameManager { get; }
        ICharacterData CharacterData { get; }
        ICharacterAnimationController AnimationController { get; }
        ICharacterCombatController CombatController { get; }
        void Initialize(IGameManager gameManager, CharacterTemplate characterTemplate);
    }
}
