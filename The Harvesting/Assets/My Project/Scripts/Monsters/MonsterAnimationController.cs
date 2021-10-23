using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
                
                animator.SetTrigger("Death");
                deathAnimationPlayed = true;
                return;
            }

            animator.SetBool("Stunned", CombatController.Stunned(CombatController.CurrentCharacterState()));
            animator.SetBool("Running", MovementController.IsRunning());
            
        }

    }
}