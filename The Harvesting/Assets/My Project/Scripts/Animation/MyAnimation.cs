using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting {
    [CreateAssetMenu(fileName ="new myAnimation", menuName = "Data/Animation/My Animation")]
    public class MyAnimation : ScriptableObject
    {
        public AnimationClip Animation;
        [Range(0,1)]
        public float ImpactPoint = 0f;
        private int animationHash;

        public void OnEnable()
        {
                animationHash = Animator.StringToHash(Animation.name);
        }

        public int AnimationHash()
        {
            return animationHash;
        }

        public float ImpactPointSeconds()
        {
            return ImpactPoint * Animation.length;
        }
    }
}