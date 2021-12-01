using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    public abstract class CharacterAnimationController : MonoBehaviour
    {
        protected Animator _animator;
        public Animator Animator { get => _animator; }
        
        protected void Initialize(Animator animator)
        {
            _animator = animator;
            if (_animator == null)
            {
                _animator = GetComponentInChildren<Animator>();
                if (_animator == null)
                {
                    Debug.Log("Animator not found in children of CharacterCore: CharacterAnimationController.");
                }
            }
        }

    }
}