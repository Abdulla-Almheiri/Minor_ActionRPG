using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting {
    [CreateAssetMenu(fileName ="new animation data", menuName = "Data/Animation/Character Animation Data")]
    public class CharacterAnimationData : ScriptableObject
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