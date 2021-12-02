using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// CharacterCore class. This is used as the Core for the player and monsters.
    /// </summary>
    public abstract class CharacterCore : MonoBehaviour, ICharacterCore
    {
        public ICharacterData CharacterData { get; protected set; }

        public IGameManager GameManager { get; protected set; }

        public ICharacterAnimationController AnimationController { get; protected set; }

        public ICharacterCombatController CombatController { get; protected set; }

        public void Initialize(IGameManager gameManager, CharacterTemplate characterTemplate)
        {
            GameManager = gameManager ?? FindObjectOfType<GameManager>();
            CharacterData = new CharacterData();
            CharacterData.Initialize(this, characterTemplate);
        }
    }
}