using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    [RequireComponent(typeof(MonsterCore))]
    public class MonsterAnimationController : CharacterAnimationController
    {
        private MonsterCore _core;

        private bool deathAnimationPlayed = false;

        protected void Initialize(MonsterCore monsterCore, Animator animator)
        {
            base.Initialize(animator);
            _core = monsterCore ?? GetComponent<MonsterCore>();
        }

        // Update is called once per frame
        void Update()
        {
            HandleAnimations();

        }
        private void Start()
        {
            Initialize(null, null);
        }
        private void HandleAnimations()
        {
           /* if(deathAnimationPlayed == true)
            {
                return;
            }

            if(_combatController.Dead(_combatController.CurrentCharacterState()))
            {
                var monsterNavMesh = GetComponent<NavMeshAgent>();
                monsterNavMesh.enabled = false;
                var rigidBody = GetComponentInChildren<Rigidbody>();
                var collider = GetComponentInChildren<Collider>();
                Destroy(rigidBody);
                Destroy(collider);
                _animator.SetTrigger("Death");
                deathAnimationPlayed = true;
                return;
            }

            _animator.SetBool("Stunned", _combatController.Stunned(_combatController.CurrentCharacterState()));
            _animator.SetBool("Running", _movementController.IsRunning());
           */
            
        }

        public void AddEffect(GameObject effect, float duration)
        {
            if(effect != null)
            {
                var spawn = Instantiate(effect, transform);
                Destroy(spawn, duration);
            }
        }
    }
}