using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using FMODUnity;

namespace Harvesting {

   /* [RequireComponent(typeof(PlayerAnimationController))]
    [RequireComponent(typeof(PlayerCombatController))]
    [RequireComponent(typeof(PlayerSkillController))]
    [RequireComponent(typeof(PlayerItemController))]
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(PlayerUIController))]
    [RequireComponent(typeof(PlayerSFXController))]*/

    public class PlayerCore: MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private PlayerTemplate _template;

        public PlayerAnimationController AnimationController { get; private set; }
        public PlayerCombatController CombatController { get; private set; }
        public PlayerSkillController SkillController { get; private set; }
        public PlayerItemController ItemController { get; private set; }
        public PlayerMovementController MovementController { get; private set; }
        public PlayerUIController UIController { get; private set; }
        public PlayerSFXController SFXController { get; private set; }
        public Player Data { get; private set; }
        public GameManager GameManager { get => _gameManager; }

        public void Initialize(GameManager gameManager, PlayerTemplate template)
        {
            _gameManager = _gameManager ?? gameManager ?? FindObjectOfType<GameManager>();
            _template = _template ?? template ?? _gameManager.PlayerTemplate;

            AnimationController = GetComponent<PlayerAnimationController>();
            CombatController = GetComponent<PlayerCombatController>();
            SkillController = GetComponent<PlayerSkillController>();
            ItemController = GetComponent<PlayerItemController>();
            MovementController = GetComponent<PlayerMovementController>();
            UIController = GetComponent<PlayerUIController>();
            SFXController = GetComponent<PlayerSFXController>();

            Data = new Player(this, _gameManager.CoreAttributes, _template);
        }

        public void Awake()
        {
            Initialize(null, null);
        }


        public void Update()
        {
            //TEST
            if (Input.GetKeyDown(KeyCode.F))
            {
                Data.LevelUp(5);
            }
        }
    }
}
