using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayerCore : ICharacterCore
    {
        PlayerData PlayerData { get; }
        new IPlayerAnimationController AnimationController { get; }
        new IPlayerCombatController CombatController { get; }
        new IPlayerSkillController SkillController { get; }
        new IPlayerMovementController MovementController { get; }
        new IPlayerInputController InputController { get; }
        new IPlayerUIController UIController { get; }
        new IPlayerItemController ItemController { get; }
        new IPlayerSFXController SFXController { get; }
        void Initialize(IGameManager gameManager, IPlayerTemplate playerTemplate);
    }
}