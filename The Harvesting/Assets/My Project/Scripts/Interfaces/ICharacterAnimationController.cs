using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public interface ICharacterAnimationController
    {
        ICharacterCore Core { get; }
        Animator Animator { get; }
        void HandleRunningAnimation();
        void SpawnVisualEffect(CharacterVisualEffect characterVisualEffect, float duration);
        void Initialize(ICharacterCore characterCore, Animator animator);
        void FaceDirection(Vector3 direction);
        void PlaySkillAnimation(Skill skill, out float impactPointInSeconds);
    }
}