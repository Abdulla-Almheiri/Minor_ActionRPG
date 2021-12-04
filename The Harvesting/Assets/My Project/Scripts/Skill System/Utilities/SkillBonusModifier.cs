using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class SkillBonusModifier
    {
        public CharacterModifier Duration;
        public CharacterModifier Potency;
        public CharacterModifier CriticalChance;
        public CharacterModifier CriticalDamage;
        public CharacterModifier ManaCostReduction;
        public CharacterModifier CooldownReduction;
        public CharacterModifier TriggerChance;

        public SkillBonusModifier()
        {
            Duration = new CharacterModifier();
            Potency = new CharacterModifier();
            CriticalChance = new CharacterModifier();
            CriticalDamage = new CharacterModifier();
            ManaCostReduction = new CharacterModifier();
            CooldownReduction = new CharacterModifier();
            TriggerChance = new CharacterModifier();
        }
    }
}