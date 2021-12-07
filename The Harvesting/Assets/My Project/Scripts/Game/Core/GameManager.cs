using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{

    public class GameManager : MonoBehaviour, IGameManager
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Canvas _staticCanvas;
        [SerializeField] private Canvas _dynamicCanvas;
        [SerializeField] private Transform _playerCheckPoint;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private CoreAttributesTemplate _coreAttributesTemplate;
        [SerializeField] private CombatSettings _combatSettings;
        [SerializeField] private InputKeyData _inputKeyData;
        [SerializeField] private LayerMask _walkableLayer;
        [SerializeField] private LayerMask _playerLayer;
        [SerializeField] private PlayerTemplate _playerTemplate;
        [SerializeField] private SkillUIScript _skillUI;
        [SerializeField] private MonsterTemplate _monsterTemplate;
        [SerializeField] private GameObject _monsterPrefab;
        [SerializeField] private Transform _monsterSpawnPoint;
        [SerializeField] private MonsterAI _monsterAI;

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
        public PlayerCore PlayerCore { get; protected set; }
        public CoreAttributesTemplate CoreAttributes { get => _coreAttributesTemplate; }

        public InputKeyData InputKeyData { get => _inputKeyData; }
        public LayerMask Layer { get => _walkableLayer; }

        public GameDialogueController GameDialogueController { get => _gameDialogueController; }
        public GameInputController GameInputController { get => _gameInputController; }
        public GameItemsController GameItemsController { get => _gameItemsController; }
        public GameLevelController GameLevelController { get => _gameLevelController; }
        public GameMonsterSpawnController GameMonsterSpawnController { get => _gameMonsterSpawnController; }
        public GameNPCController GameNPCController { get => _gameNPCController; }
        public GameQuestController GameQuestController { get => _gameQuestController; }
        public GameSaveLoadController GameSaveLoadController { get => _gameSaveLoadController; }
        public GameTutorialController GameTutorialController { get => _gameTutorialController; }
        public CombatSettings CombatSettings { get => _combatSettings; }
        public IPlayerTemplate PlayerTemplate { get => _playerTemplate; }

        public CoreAttributesTemplate CoreAttributesTemplate { get => _coreAttributesTemplate; }

        public IGameUIController UIController { get; protected set; }

        public SkillUIScript SkillUI { get => _skillUI; }
        public IMonsterTemplate MonsterTemplate { get => _monsterTemplate;  }

        public LayerMask PlayerLayer { get => _playerLayer; }
        void Awake()
        {
            Initialize();
            SpawnPlayer(_playerCheckPoint);
            InitializeCamera();
            SpawnMonster(_monsterPrefab, _monsterSpawnPoint,  MonsterTemplate, _monsterAI);
        }

        private void Initialize()
        {
            //_playerCore = _playerCore ? _playerCore : FindObjectOfType<PlayerCore>();

            _camera = _camera ? _camera : Camera.main;
            _coreAttributesTemplate = _coreAttributesTemplate ? _coreAttributesTemplate : FindObjectOfType<CoreAttributesTemplate>();

            _gameDialogueController = GetComponent<GameDialogueController>();
            _gameInputController = GetComponent<GameInputController>();
            _gameItemsController = GetComponent<GameItemsController>();
            _gameLevelController = GetComponent<GameLevelController>();
            _gameMonsterSpawnController = GetComponent<GameMonsterSpawnController>();
            _gameNPCController = GetComponent<GameNPCController>();
            _gameQuestController = GetComponent<GameQuestController>();
            _gameSaveLoadController = GetComponent<GameSaveLoadController>();
            _gameTutorialController = GetComponent<GameTutorialController>();
            UIController = GetComponent<GameUIController>();
            UIController.Initialize(this);
        }

        public void SpawnPlayer(Transform checkPoint)
        {
            if(PlayerCore != null)
            {
                return;
            }

            PlayerCore = Instantiate(_playerPrefab, checkPoint).GetComponent<PlayerCore>();
            PlayerCore.transform.SetParent(null);
            PlayerCore.Initialize(this, PlayerTemplate);
            
        }

        public IMonsterCore SpawnMonster(GameObject monsterPrefab, Transform spawnPoint, IMonsterTemplate template, MonsterAI monsterAI)
        {
            var monster = Instantiate(monsterPrefab, spawnPoint).GetComponent<MonsterCore>();
            monster.transform.SetParent(null);
            monster.Initialize(this, template, monsterAI);

            return monster;
        }

        protected void InitializeCamera()
        {
            Camera.GetComponent<CamFollowPlayerScript>().Initialize(PlayerCore);
        }
    }
}