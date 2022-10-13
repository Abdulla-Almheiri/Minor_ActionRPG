using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    public abstract class CharacterAnimationController : MonoBehaviour, ICharacterAnimationController
    {
        public ICharacterCore Core { get; protected set; }
        public Animator Animator { get; protected set; }

        public void Initialize(ICharacterCore core, Animator animator)
        {
            Core = core;
            Animator = animator;
            if (Animator == null)
            {  
                Debug.Log("Animator not found in children of CharacterCore: CharacterAnimationController.");
            }
        }

        protected void Update()
        {
            if (Core.CombatController?.IsAlive != true)
            {
                return;
            }
            HandleRunningAnimation();
        }

        public void HandleRunningAnimation()
        {

            if (Core.MovementController.IsRunning())
            {
                Animator.SetBool("Running", true);
            }
            else
            {
                Animator.SetBool("Running", false);
            }
        }

        public void SpawnVisualEffect(CharacterVisualEffect characterVisualEffect, float duration)
        {
            
        }

        public void FaceDirection(Vector3 direction)
        {
            if(Core.CombatController.IsAlive != true)
            {
                return;
            }

            Core.MovementController.StopMoving();
            var dir = (direction - Core.MovementController.Transform.position);
            dir.y = 0;
            dir = dir.normalized;
            Core.MovementController.Transform.rotation = Quaternion.LookRotation(dir);
        }

        public virtual void PlaySkillAnimation(Skill skill, out float impactPointInSeconds)
        {
            impactPointInSeconds = 0;

            if (Core.CombatController.IsAlive != true)
            {
                return;
            }

            
            if(skill == null)
            {
                return;
            }

            impactPointInSeconds = skill.PlayerAnimation ? skill.PlayerAnimation.AnimationHitFrameInSeconds() : 0f;

            if(skill.PlayerAnimation?.Animation == null)
            {
                return;
            }

            Debug.Log("SKILL ANIMATION    :   " + skill.name + "      " + skill.PlayerAnimation.name);
            Animator.SetTrigger(skill.PlayerAnimation.AnimationHash());
        }

        public void PlayDeathAnimation()
        {
            Animator.SetTrigger("Death");
        }
    }
}