using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using FMODUnity;

namespace Harvesting {

    [RequireComponent(typeof(PlayerAnimationController))]
    [RequireComponent(typeof(PlayerCombatController))]
    [RequireComponent(typeof(PlayerSkillController))]
    [RequireComponent(typeof(PlayerItemController))]
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(PlayerUIController))]
    [RequireComponent(typeof(PlayerSFXController))]

    public class PlayerCore : MonoBehaviour
    {
        [SerializeField] private PlayerTemplate _playerTemplate;
        private GameCore _gameCore;
        private PlayerAnimationController _playerAnimationController;
        private PlayerCombatController _playerCombatController;
        private PlayerSkillController _playerSkillController;
        private PlayerItemController _playerItemController;
        private PlayerMovementController _playerMovementController;
        private PlayerUIController _playerUIController;
        private PlayerSFXController _playerSFXController;

        private Player _player;

        public PlayerData PlayerData;
        public GameObject CharacterScreen;
        public LayerMask ItemUILayer;

        public Inventory Inventory;
        public ItemTemplate StartingItem;

        private bool _initialized = false;

        public PlayerAnimationController PlayerAnimationController { get => _playerAnimationController; }
        public PlayerCombatController PlayerCombatController { get => _playerCombatController; }
        public PlayerSkillController PlayerSkillController { get => _playerSkillController; }
        public PlayerItemController PlayerItemController { get => _playerItemController; }
        public PlayerMovementController PlayerMovementController { get => _playerMovementController; }
        public PlayerUIController PlayerUIController { get => _playerUIController; }
        public PlayerSFXController PlayerSFXController { get => _playerSFXController; }
        public Player Player { get => _player; }

        public void Start()
        {
            Initialize();
        }


        public void Update()
        {
            if(!_initialized)
            {
                Initialize();
                _initialized = true;
            }
            UpdatePlayerUI();


        }


        private void UpdatePlayerUI()
        {
            //UIController.UpdateHealthPercentage(_character.HealthPercentage());
            //print("Health Percentage is  :   " + _player.HealthPercentage());
        }

        private void Initialize()
        {
            _gameCore = FindObjectOfType<GameCore>();
            //_player = new Player (_playerTemplate.CharacterTemplate);
            _playerAnimationController = GetComponent<PlayerAnimationController>();
            _playerCombatController = GetComponent<PlayerCombatController>();
            _playerSkillController = GetComponent<PlayerSkillController>();
            _playerItemController = GetComponent<PlayerItemController>();
            _playerMovementController = GetComponent<PlayerMovementController>();
            _playerUIController = GetComponent<PlayerUIController>();
            _playerSFXController = GetComponent<PlayerSFXController>();

            //_player.TakeDamage(30f);
        }
    }
}
