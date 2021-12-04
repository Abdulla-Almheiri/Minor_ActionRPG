using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(GameManager))]
    public class GameUIController : MonoBehaviour, IGameUIController
    {
        public IGameManager GameManager { get; protected set; }
        [SerializeField] private Canvas _dynamicCanvas;
        [SerializeField] private Canvas _staticCanvas;
        
        public FloatingCombatTextManager CombatTextManager { get; protected set; }
        public Canvas DynamicCanvas { get => _dynamicCanvas; }
        public Canvas StaticCanvas { get => _staticCanvas; }

        [SerializeField] private GameObjectPool _combatTextPool;
        public void Initialize(IGameManager gameManager)
        {
            GameManager = gameManager;
            CombatTextManager = new FloatingCombatTextManager(_combatTextPool, DynamicCanvas, GameManager.Camera);
        }

        protected void Start()
        {
            if(_dynamicCanvas == null)
            {
                Debug.Log("No dynammic canvas has been assigned in GameManager.GameUIController.");
            }

            if (_staticCanvas == null)
            {
                Debug.Log("No static canvas has been assigned in GameManager.GameUIController.");
            }
        }
    }
}