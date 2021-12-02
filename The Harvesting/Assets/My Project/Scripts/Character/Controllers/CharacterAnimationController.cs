using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    public abstract class CharacterAnimationController : MonoBehaviour, ICharacterAnimationController
    {
        public ICharacterCore Core { get; protected set; }
        public ICharacterMovementController MovementController { get; protected set; }
        public Animator Animator { get; protected set; }

        public void Initialize(ICharacterCore core, Animator animator)
        {
            Core = core ?? GetComponent<ICharacterCore>() as ICharacterCore;
            Animator = animator ?? GetComponentInChildren<Animator>(); ;

            if (Animator == null)
            {  
                Debug.Log("Animator not found in children of CharacterCore: CharacterAnimationController.");
            }
        }

        public void HandleRunningAnimation()
        {
            if (MovementController.IsRunning())
            {
                Animator.SetBool("Running", true);
            }
            else
            {
                Animator.SetBool("Running", false);
                Animator.SetBool("Idle", true);
            }
        }

    }
}