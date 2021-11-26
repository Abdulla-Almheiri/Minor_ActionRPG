using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(FloatingCombatTextManager))]

    public class GameCore : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Canvas _staticCanvas;
        [SerializeField] private Canvas _dynamicCanvas;
        [SerializeField] private PlayerCore _playerCore;
        [SerializeField] private CoreAttributes _coreAttributes;

        private FloatingCombatTextManager _combatTextManager;

        public Camera Camera { get => _camera; }
        public Canvas StaticCanvas { get => _staticCanvas; }
        public Canvas DynamicCanvas { get => _dynamicCanvas; }
        public PlayerCore PlayerCore { get => _playerCore; }
        public CoreAttributes CoreAttributes { get => _coreAttributes; }

        void Awake()
        {
            InitializeAwake();
        }

        private void Start()
        {
            InitializeStart();
        }

        void Update()
        {

        }

        private void InitializeAwake()
        {
            _camera = _camera ? _camera : Camera.main;
            _combatTextManager = GetComponent<FloatingCombatTextManager>();
            _coreAttributes = _coreAttributes ? _coreAttributes : FindObjectOfType<CoreAttributes>();

        }

        private void InitializeStart()
        {
            _playerCore = _playerCore ? _playerCore : FindObjectOfType<PlayerCore>();
        }
    }
}