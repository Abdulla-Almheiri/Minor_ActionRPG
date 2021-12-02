using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(MonsterAnimationController))]
    [RequireComponent(typeof(MonsterCombatController))]
    [RequireComponent(typeof(MonsterSkillController))]
    [RequireComponent(typeof(MonsterMovementController))]
    [RequireComponent(typeof(MonsterUIController))]
    [RequireComponent(typeof(MonsterSFXController))]

    public class MonsterCore : CharacterCore
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private MonsterTemplate _template;

        public MonsterData Data { get; private set; }

        private MonsterAnimationController _animationController;
        private MonsterCombatController _combatController;
        private MonsterSkillController _skillController;
        private MonsterMovementController _movementController;
        private MonsterUIController _UIController;
        private MonsterSFXController _SFXController;


        public MonsterAnimationController AnimationController { get => _animationController; }
        public MonsterCombatController CombatController { get => _combatController;}
        public MonsterSkillController SkillController { get => _skillController; }
        public MonsterMovementController MovementController { get => _movementController; }
        public MonsterUIController UIController { get => _UIController; }
        public MonsterSFXController SFXController { get => _SFXController; }

        public void Start()
        {
            Initialize(null, null);
        }


        private void Initialize(GameManager gameManager, MonsterTemplate template)
        {
            _gameManager = _gameManager ?? gameManager ?? FindObjectOfType<GameManager>();
            _template = _template ?? template ?? FindObjectOfType<MonsterTemplate>();

            _animationController = GetComponent<MonsterAnimationController>();
            _combatController = GetComponent<MonsterCombatController>();
            _skillController = GetComponent<MonsterSkillController>();
            _movementController = GetComponent<MonsterMovementController>();
            _UIController = GetComponent<MonsterUIController>();
            _SFXController = GetComponent<MonsterSFXController>();

            Data = new MonsterData(this, _gameManager.CoreAttributes, _template);
        }
    }
}