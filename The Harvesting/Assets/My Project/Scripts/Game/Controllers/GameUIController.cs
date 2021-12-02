using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(GameManager))]
    public class GameUIController : MonoBehaviour
    {
        private FloatingCombatTextManager _combatTextManager;
        [SerializeField] private Canvas _dynamicCanvas;
        [SerializeField] private Canvas _staticCanvas;
        
        public FloatingCombatTextManager CombatTextManager { get => _combatTextManager; }
        public Canvas DynamicCanvas { get => _dynamicCanvas; }
        public Canvas StaticCanvas { get => _staticCanvas; }

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