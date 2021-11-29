using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class SkillActionSource
    {
        private SkillAction _skillAction;
        private Character _character;

        public SkillAction SkillAction { get => _skillAction; }
        public Character Character { get => _character; }

        public bool IsEqual(SkillActionSource skillActionSource)
        {
            return (skillActionSource.SkillAction == SkillAction && skillActionSource.Character == Character);
        }

        public SkillActionSource(Character character, SkillAction skillAction)
        {
            _character = character;
            _skillAction = skillAction;
        }
    }
}