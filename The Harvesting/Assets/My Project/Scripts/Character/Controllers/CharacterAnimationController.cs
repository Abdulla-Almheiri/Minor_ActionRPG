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

        public void HandleRunningAnimation()
        {
            if (Core.MovementController.IsRunning())
            {
                Animator.SetBool("Running", true);
            }
            else
            {
                Animator.SetBool("Running", false);
                Animator.SetBool("Idle", true);
            }
        }

        public void SpawnVisualEffect(CharacterVisualEffect characterVisualEffect, float duration)
        {
            
        }

        public void FaceDirection(Vector3 direction)
        {
            Animator.SetBool("Running", false);
            var dir = (direction - Core.MovementController.Transform.position);
            dir.y = 0;
            dir = dir.normalized;
            Core.MovementController.Transform.rotation = Quaternion.LookRotation(dir);
        }

        public abstract void PlaySkillAnimation(Skill skill, out float impactPointInSeconds);
    }
}