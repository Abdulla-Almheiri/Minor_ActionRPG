using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// CharacterCore class. This is used as the Core for the player and monsters.
    /// </summary>
    public abstract class CharacterCore : MonoBehaviour
    {
        [SerializeField] protected GameManager _gameManager;
        [SerializeField] protected CharacterTemplate _template;
        protected Character _data;

        protected CharacterAnimationController _animationController;
        protected CharacterCombatController _combatController;
        protected CharacterSkillController _skillController;
        protected CharacterMovementController _movementController;

        public CharacterAnimationController AnimationController { get => _animationController; }
        public CharacterCombatController CombatController { get => _combatController; set => _combatController = value; }
        public CharacterSkillController SkillController { get => _skillController; set => _skillController = value; }
        public CharacterMovementController MovementController { get => _movementController; set => _movementController = value; }
        public GameManager GameManager { get => _gameManager;}

        public virtual void Initialize(GameManager gameManager)
        {
            
            _animationController = GetComponent<CharacterAnimationController>();
            _combatController = GetComponent<CharacterCombatController>();
            _skillController = GetComponent<CharacterSkillController>();
            _movementController = GetComponent<CharacterMovementController>();

        }
    }
}