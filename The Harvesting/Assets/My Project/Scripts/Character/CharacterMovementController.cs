using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

namespace Harvesting
{
    /// <summary>
    /// CharacterMovementController Monobehavior. Controlls Character movement. Requires NavMeshAgent component.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class CharacterMovementController : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;

        public NavMeshAgent NavMeshAgent { get => navMeshAgent; }

        void Start()
        {
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Caching commponents.
        /// </summary>
        public void Initialize()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            if(navMeshAgent == null)
            {
                Debug.Log("No NavMeshAgent component found on CharacterCore: CharacterMovementController.");
            }


        }
    }
}