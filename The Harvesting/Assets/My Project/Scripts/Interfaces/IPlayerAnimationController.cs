using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayerAnimationController : ICharacterAnimationController
    {
        new IPlayerCore Core { get; }
        CharacterAnimationData DefaultSkillAnimation { get;  }
        void RotateToMouseDirection();
        void PlayPlayerSkillAnimation(Skill skill);
        public void Initialize(IPlayerCore playerCore, Animator animator);
    }
}