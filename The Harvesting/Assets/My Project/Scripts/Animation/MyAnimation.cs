using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting {
    public class MyAnimation : MonoBehaviour
    {
        public Animator Animator;
        public AnimationClip Animation;
        private int animationHash;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Animator.Play(animationHash);
            }
        }

        public void OnEnable()
        {
            animationHash = Animator.StringToHash(Animation.name);
        }
    }
}