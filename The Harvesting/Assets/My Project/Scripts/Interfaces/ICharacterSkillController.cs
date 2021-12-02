using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface ICharacterSkillController 
    {
        bool ActivateSkill(Skill skill);
        float SkillRecharge(Skill skill, out float seconds);
    }
}