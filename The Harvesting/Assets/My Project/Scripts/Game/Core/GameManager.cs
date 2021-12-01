using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(FloatingCombatTextManager))]

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Canvas _staticCanvas;
        [SerializeField] private Canvas _dynamicCanvas;
        [SerializeField] private PlayerCore _playerCore;
        [SerializeField] private CoreAttributes _coreAttributes;
        [SerializeField] private CombatSettings _combatSettings;
        [SerializeField] private LayerMask _layer;
        [SerializeField] private PlayerTemplate _playerTemplate;

        private FloatingCombatTextManager _combatTextManager;

        private GameDialogueController _gameDialogueController;
        private GameInputController _gameInputController;
        private GameItemsController _gameItemsController;
        private GameLevelController _gameLevelController;
        private GameMonsterSpawnController _gameMonsterSpawnController;
        private GameNPCController _gameNPCController;
        private GameQuestController _gameQuestController;
        private GameSaveLoadController _gameSaveLoadController;
        private GameTutorialController _gameTutorialController;
        private GameUIController _gameUIController;



        public Camera Camera { get => _camera; }
        public Canvas StaticCanvas { get => _staticCanvas; }
        public Canvas DynamicCanvas { get => _dynamicCanvas; }
        public PlayerCore PlayerCore { get => _playerCore; }
        public CoreAttributes CoreAttributes { get => _coreAttributes; }

        public LayerMask Layer { get => _layer; }

        public GameDialogueController GameDialogueController { get => _gameDialogueController; }
        public GameInputController GameInputController { get => _gameInputController; }
        public GameItemsController GameItemsController { get => _gameItemsController; }
        public GameLevelController GameLevelController { get => _gameLevelController; }
        public GameMonsterSpawnController GameMonsterSpawnController { get => _gameMonsterSpawnController; }
        public GameNPCController GameNPCController { get => _gameNPCController; }
        public GameQuestController GameQuestController { get => _gameQuestController; }
        public GameSaveLoadController GameSaveLoadController { get => _gameSaveLoadController; }
        public GameTutorialController GameTutorialController { get => _gameTutorialController; }
        public GameUIController GameUIController { get => _gameUIController; }
        public CombatSettings CombatSettings { get => _combatSettings; }
        public PlayerTemplate PlayerTemplate { get => _playerTemplate; }

        void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _playerCore = _playerCore ? _playerCore : FindObjectOfType<PlayerCore>();

            _camera = _camera ? _camera : Camera.main;
            _combatTextManager = GetComponent<FloatingCombatTextManager>();
            _coreAttributes = _coreAttributes ? _coreAttributes : FindObjectOfType<CoreAttributes>();

            _gameDialogueController = GetComponent<GameDialogueController>();
            _gameInputController = GetComponent<GameInputController>();
            _gameItemsController = GetComponent<GameItemsController>();
            _gameLevelController = GetComponent<GameLevelController>();
            _gameMonsterSpawnController = GetComponent<GameMonsterSpawnController>();
            _gameNPCController = GetComponent<GameNPCController>();
            _gameQuestController = GetComponent<GameQuestController>();
            _gameSaveLoadController = GetComponent<GameSaveLoadController>();
            _gameTutorialController = GetComponent<GameTutorialController>();
            _gameUIController = GetComponent<GameUIController>();
        }
    }
}