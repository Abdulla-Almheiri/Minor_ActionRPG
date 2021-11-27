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

    public class MonsterCore : MonoBehaviour
    {
        [SerializeField] private GameCore _gameCore;
        public PlayerCore PlayerCore;
        public CharacterData MonsterData;
        public Canvas DynamicCanvas;
        public ItemGroundPrefab ItemGroundUIPrefab;
        public List<ItemDrop> Loot = new List<ItemDrop>();
        private int level;

        private MonsterAnimationController _animationController;
        private MonsterCombatController _combatController;
        private MonsterSkillController _skillController;
        private MonsterMovementController _movementController;
        private MonsterUIController _UIController;
        private MonsterSFXController _SFXController;


        public CharacterState DeadState;

        public MonsterAnimationController AnimationController { get => _animationController; }
        public MonsterCombatController CombatController { get => _combatController;}
        public MonsterSkillController SkillController { get => _skillController; }
        public MonsterMovementController MovementController { get => _movementController; }
        public MonsterUIController UIController { get => _UIController; }
        public MonsterSFXController SFXController { get => _SFXController; }

        public void Start()
        {
            Initialize();
        }


        public void DropItems()
        {
            int i = 0;
            foreach (ItemDrop item in Loot)
            {
                if (Random.Range(0, 100) <= item.Chance)
                {
                    var spawn = Instantiate(ItemGroundUIPrefab, DynamicCanvas.transform);
                    spawn.GetComponent<ItemGroundPrefab>().Item = item.Item.Generate(level, level);
                    //spawn.transform.SetParent(null);
                    spawn.WorldPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    i++;
                }
            }
        }

        private void Initialize()
        {
            _gameCore = _gameCore ? _gameCore : FindObjectOfType<GameCore>();

            _animationController = GetComponent<MonsterAnimationController>();
            _combatController = GetComponent<MonsterCombatController>();
            _skillController = GetComponent<MonsterSkillController>();
            _movementController = GetComponent<MonsterMovementController>();
            _UIController = GetComponent<MonsterUIController>();
            _SFXController = GetComponent<MonsterSFXController>();
        }
    }
}