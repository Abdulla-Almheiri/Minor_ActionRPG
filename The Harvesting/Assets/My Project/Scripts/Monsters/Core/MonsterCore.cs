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

    public class MonsterCore : CharacterCore, IMonsterCore
    {
        [SerializeField] private MonsterTemplate _monsterTemplate;

        public new IMonsterTemplate Template { get => _monsterTemplate;  }
        public IMonsterData MonsterData { get; protected set; }


        public new IMonsterAnimationController AnimationController { get; protected set; }
        public new IMonsterCombatController CombatController { get; protected set; }
        public new IMonsterSkillController SkillController { get; protected set; }
        public new IMonsterMovementController MovementController { get; protected set; }
        public new IMonsterUIController UIController { get; protected set; }
        public new IMonsterSFXController SFXController { get; protected set; }


        public void Start()
        {
            Initialize(null, null);
        }


        private void Initialize(IGameManager gameManager, IMonsterTemplate template)
        {
            GameManager = gameManager ?? FindObjectOfType<GameManager>();
            base.Template = _monsterTemplate ?? template ?? FindObjectOfType<MonsterTemplate>();

            AnimationController = GetComponent<IMonsterAnimationController>();
            CombatController = GetComponent<IMonsterCombatController>();
            SkillController = GetComponent<IMonsterSkillController>();
            MovementController = GetComponent<IMonsterMovementController>();
            UIController = GetComponent<IMonsterUIController>();
            SFXController = GetComponent<IMonsterSFXController>();

            MonsterData = new MonsterData();
            MonsterData.Initialize(Template);
        }
    }
}