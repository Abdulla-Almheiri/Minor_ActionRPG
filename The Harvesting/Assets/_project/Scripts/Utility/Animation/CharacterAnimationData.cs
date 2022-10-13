using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting {
    [CreateAssetMenu(fileName ="new animation data", menuName = "Data/Animation/Character Animation Data")]
    public class CharacterAnimationData : ScriptableObject
    {
        public Animator AnimatorController;
        public AnimationClip Animation;
        public Transform SkillVFXSpawnPoint;
        /*[Range(0.1f, 5f)]
        public float AnimationSpeed = 1f;*/
        [Range(0,1f)]
        public float AnimationHitFramePoint = 0f;
        private int animationHash;

        public void OnEnable()
        {
            animationHash = Animator.StringToHash(Animation.name);
        }

        public int AnimationHash()
        {
            return animationHash;
        }

        public float AnimationHitFrameInSeconds()
        {
            return AnimationHitFramePoint * Animation.length;
        }
    }
}