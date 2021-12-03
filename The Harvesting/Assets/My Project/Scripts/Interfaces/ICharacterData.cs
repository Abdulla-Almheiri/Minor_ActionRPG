using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface ICharacterData
    {
        List<Skill> Abilities { get; }
        Dictionary<Attribute, CharacterModifier> CoreAttributes { get; }
        Dictionary<Attribute, CharacterModifier> SecondaryAttributes { get; }
        Dictionary<SkillActionElement, CharacterModifier> ResistanceAttributes { get; }
        Dictionary<SkillActionSource, SkillActionSource> StatusEffects { get; }
        Dictionary<Skill, CharacterModifier> SkillBonusAttributes { get; }
        void Initialize(ICharacterCore core, ICharacterTemplate characterTemplate);
    }
}