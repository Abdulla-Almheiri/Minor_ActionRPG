using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting {
    public class CharacterAnimationControllerOld : MonoBehaviour
    {
        private Animator animator;
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TryPlayAnimation(MyAnimation animation)
        {

        }

        private void PlayAnimation(MyAnimation animation)
        {
            animator.Play(animation.AnimationHash());
        }

        public void FreezeAnimation()
        {
            animator.speed = 0;
        }

        public void UnfreezeAnimation()
        {
            animator.speed = 1;
        }
    }
}