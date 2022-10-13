using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    /*[RequireComponent(typeof(MonsterAnimationController))]
    [RequireComponent(typeof(MonsterCombatController))]
    [RequireComponent(typeof(MonsterSkillController))]
    [RequireComponent(typeof(MonsterMovementController))]
    [RequireComponent(typeof(MonsterUIController))]
    [RequireComponent(typeof(MonsterSFXController))]
    */
    public class MonsterCore : CharacterCore, IMonsterCore
    {
        [SerializeField] private MonsterTemplate _monsterTemplate;

        public new IMonsterTemplate Template { get => _monsterTemplate;  }
        public MonsterData MonsterData { get; protected set; }


        public new IMonsterAnimationController AnimationController { get; protected set; }
        public new IMonsterCombatController CombatController { get; protected set; }
        public new IMonsterSkillController SkillController { get; protected set; }
        public new IMonsterMovementController MovementController { get; protected set; }
        public new IMonsterUIController UIController { get; protected set; }
        public new IMonsterSFXController SFXController { get; protected set; }
        public new IMonsterAIController AIController { get; protected set; }

        public void Initialize(IGameManager gameManager, IMonsterTemplate template, MonsterAI monsterAI)
        {
            GameManager = gameManager;
            
            var animator = GetComponentInChildren<Animator>();
            var navMeshAgent = GetComponent<NavMeshAgent>();

            MonsterData = new MonsterData(template);

            base.Initialize(gameManager, template, animator, gameObject, navMeshAgent, transform, null);

            MovementController = GetComponent<MonsterMovementController>();
            MovementController.Initialize(this, navMeshAgent, transform);

            AnimationController = GetComponent<MonsterAnimationController>();
            AnimationController.Initialize(this, animator);

            CombatController = GetComponent<MonsterCombatController>();
            CombatController.Initialize(this);

            SkillController = GetComponent<MonsterSkillController>();
            SkillController.Initialize(this, GameManager.CombatSettings, null);

            UIController = GetComponent<MonsterUIController>();
            UIController.Initialize(this);

            SFXController = GetComponent<MonsterSFXController>();
            SFXController.Initialize(this);

            AIController = GetComponent<MonsterAIController>();
            AIController.Initialize(this, monsterAI);
        }
    }
}