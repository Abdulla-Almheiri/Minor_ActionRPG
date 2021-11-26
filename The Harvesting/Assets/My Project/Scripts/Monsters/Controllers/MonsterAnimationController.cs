using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public class MonsterAnimationController : MonoBehaviour
    {
        public MonsterCombatController CombatController;
        public MonsterMovementController MovementController;
        public MonsterSkillController SkillController;
        public MonsterCore MonsterCore;
        private Animator animator;
        private bool deathAnimationPlayed = false;
        void Start()
        {
            animator = GetComponentInChildren<Animator>();
            CombatController = GetComponent<MonsterCombatController>();
            MovementController = GetComponent<MonsterMovementController>();
            SkillController = GetComponent<MonsterSkillController>();
        }

        // Update is called once per frame
        void Update()
        {
            HandleAnimations();

        }

        private void HandleAnimations()
        {
            if(deathAnimationPlayed == true)
            {
                return;
            }

            if(CombatController.Dead(CombatController.CurrentCharacterState()))
            {
                var monsterNavMesh = GetComponent<NavMeshAgent>();
                monsterNavMesh.enabled = false;
                /*var rigidBody = GetComponentInChildren<Rigidbody>();
                var collider = GetComponentInChildren<Collider>();
                Destroy(rigidBody);
                Destroy(collider);*/
                animator.SetTrigger("Death");
                deathAnimationPlayed = true;
                return;
            }

            animator.SetBool("Stunned", CombatController.Stunned(CombatController.CurrentCharacterState()));
            animator.SetBool("Running", MovementController.IsRunning());
            
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