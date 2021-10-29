using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    
    public class CharacterAnimationController : MonoBehaviour
    {
        private Animator animator;

        public Animator Animator { get => animator; }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Caching required components.
        /// </summary>
        private void Initialize()
        {
            animator = GetComponentInChildren<Animator>();
            if(animator == null)
            {
                Debug.Log("Animator not found in children of CharacterCore: CharacterAnimationController.");
            }
        }
    }
}