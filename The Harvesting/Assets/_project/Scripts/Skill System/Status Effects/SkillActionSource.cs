using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class SkillActionSource
    {
        private SkillAction _skillAction;
        private CharacterData _character;

        public SkillAction SkillAction { get => _skillAction; }
        public CharacterData Character { get => _character; }

        public bool IsEqual(SkillActionSource skillActionSource)
        {
            return (skillActionSource.SkillAction == SkillAction && skillActionSource.Character == Character);
        }

        public SkillActionSource(CharacterData character, SkillAction skillAction)
        {
            _character = character;
            _skillAction = skillAction;
        }
    }
}