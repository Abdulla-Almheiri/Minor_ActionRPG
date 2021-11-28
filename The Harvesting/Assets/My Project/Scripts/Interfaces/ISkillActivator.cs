using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface ISkillActivator
    {
        public bool ActivateSkill(Skill skill);
    }
}