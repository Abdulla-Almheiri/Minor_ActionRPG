using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(PlayerCombatController))]

    public class PlayerAnimationController : CharacterAnimationController
    {
        [SerializeField] private CharacterAnimationData _defaultSkillAnimation;

        public CharacterAnimationData DefaultSkillAnimation { get => _defaultSkillAnimation; }

        void Start()
        {
            Initialize(null, null);
        }

        void Update()
        {
            HandleRunningAnimation();
        }



        public void PlayPlayerSkillAnimation(Skill skill)
        {
            if (skill.PlayerAnimation != null)
            {
                Animator.SetTrigger(skill.PlayerAnimation.AnimationHash());
            } else if(_defaultSkillAnimation != null)
            {
                Animator.SetTrigger(_defaultSkillAnimation.AnimationHash());
            } else
            {
                Animator.SetTrigger("Cast3");
            }
        }



        public void RotateToMouseDirection()
        {
            Animator.SetBool("Running", false);
            if (/*!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()*/ true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayHit;

                if (Physics.Raycast(ray, out rayHit, Core.GameManager.Layer))
                {
                    var direction = (rayHit.point - transform.position);
                    direction.y = 0;
                    direction = direction.normalized;
                    transform.rotation = Quaternion.LookRotation(direction);
                }
            }
        }
    }
}