using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// Character Class. Contains Character game data.
    /// </summary>
    public class CharacterData
    {
        public bool Alive { get; protected set; } = false;
        public float CurrentHealth { get; set; }
        public float CurrentMana { get; set; }
        public List<Skill> Abilities { get; protected set; } = new List<Skill>();
        public Dictionary<Attribute, CharacterModifier> CoreAttributes { get; protected set; } = new Dictionary<Attribute, CharacterModifier>();
        public Dictionary<Attribute, CharacterModifier> SecondaryAttributes { get; protected set; } = new Dictionary<Attribute, CharacterModifier>();
        public Dictionary<SkillActionElement, CharacterModifier> ResistanceAttributes { get; protected set; } = new Dictionary<SkillActionElement, CharacterModifier>();
        public Dictionary<SkillActionSource, SkillActionSource> StatusEffects { get; protected set; } = new Dictionary<SkillActionSource, SkillActionSource>();
        public Dictionary<Skill, SkillBonusModifier> SkillBonusAttributes { get; protected set; } = new Dictionary<Skill, SkillBonusModifier>();

        

        public CharacterData(ICharacterCore core, ICharacterTemplate characterTemplate)
        {
            //CHANGE NAME WHEN NOT LAZY
            CoreAttributesTemplate coreAttributesTemplate = core.GameManager.CoreAttributesTemplate;

            CoreAttributes[coreAttributesTemplate.Level] = new CharacterModifier(characterTemplate.Level, coreAttributesTemplate.Level);
            CoreAttributes[coreAttributesTemplate.Health] = new CharacterModifier(characterTemplate.Health, coreAttributesTemplate.Health);
            CoreAttributes[coreAttributesTemplate.Mana] = new CharacterModifier(characterTemplate.Mana, coreAttributesTemplate.Mana);

            CoreAttributes[coreAttributesTemplate.Strength] = new CharacterModifier(characterTemplate.Strength, coreAttributesTemplate.Strength);
            CoreAttributes[coreAttributesTemplate.Intellect] = new CharacterModifier(characterTemplate.Intellect, coreAttributesTemplate.Intellect);
            CoreAttributes[coreAttributesTemplate.Dexterity] = new CharacterModifier(characterTemplate.Dexterity, coreAttributesTemplate.Dexterity);
            CoreAttributes[coreAttributesTemplate.Faith] = new CharacterModifier(characterTemplate.Faith, coreAttributesTemplate.Faith);
            CoreAttributes[coreAttributesTemplate.Power] = new CharacterModifier(characterTemplate.Power, coreAttributesTemplate.Power);

            CoreAttributes[coreAttributesTemplate.HealthRegen] = new CharacterModifier(characterTemplate.HealthRegen, coreAttributesTemplate.HealthRegen);
            CoreAttributes[coreAttributesTemplate.ManaRegen] = new CharacterModifier(characterTemplate.ManaRegen, coreAttributesTemplate.ManaRegen);

            CoreAttributes[coreAttributesTemplate.CriticalChance] = new CharacterModifier(characterTemplate.CriticalChance, coreAttributesTemplate.CriticalChance);
            CoreAttributes[coreAttributesTemplate.CriticalDamage] = new CharacterModifier(characterTemplate.CriticalDamageBonus, coreAttributesTemplate.CriticalDamage);

            CoreAttributes[coreAttributesTemplate.AttackSpeed] = new CharacterModifier(characterTemplate.AttackSpeed, coreAttributesTemplate.AttackSpeed);
            CoreAttributes[coreAttributesTemplate.MovementSpeed] = new CharacterModifier(characterTemplate.MovementSpeed, coreAttributesTemplate.MovementSpeed);

            CoreAttributes[coreAttributesTemplate.AllDamageTakenReduction] = new CharacterModifier(characterTemplate.AllDamageTakenReduction, coreAttributesTemplate.AllDamageTakenReduction);
            CoreAttributes[coreAttributesTemplate.AllDamageDoneIncrease] = new CharacterModifier(characterTemplate.AllDamageDoneIncrease, coreAttributesTemplate.AllDamageDoneIncrease);

            CurrentHealth = CoreAttributes[coreAttributesTemplate.Health].FinalValue();
            CurrentMana = CoreAttributes[coreAttributesTemplate.Mana].FinalValue();

            foreach (ProgressionSkill skill in characterTemplate.Abilities)
            {
                Abilities.Add(skill.Skill);
                //Debug.Log("Ability Added  :   " + skill.Skill.Name);
            }
            Alive = true;
        }
    }
}