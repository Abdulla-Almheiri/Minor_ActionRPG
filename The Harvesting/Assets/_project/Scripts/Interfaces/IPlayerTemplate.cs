using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayerTemplate : ICharacterTemplate
    {
       List<ProgressionSkill> SkillProgression { get; }
    }
}
