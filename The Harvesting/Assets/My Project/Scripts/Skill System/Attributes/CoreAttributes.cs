using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// A list of the core Attributes. Only the first instance of this object will be used.
    /// </summary>
    [CreateAssetMenu(fileName = "Core Attributes", menuName ="Data/Skills/Core Attributes")]
    public class CoreAttributes : ScriptableObject
    {
        [SerializeField] private Attribute _level;
        [SerializeField] private Attribute _experiencePoints;

        [SerializeField] private Attribute _health;
        [SerializeField] private Attribute _mana;

        [SerializeField] private Attribute _healthRegen;
        [SerializeField] private Attribute _manaRegen;

        [SerializeField] private Attribute _strength;
        [SerializeField] private Attribute _intellect;
        [SerializeField] private Attribute _dexterity;
        [SerializeField] private Attribute _faith;
        [SerializeField] private Attribute _power;


        [SerializeField] private Attribute _criticalChance;
        [SerializeField] private Attribute _criticalDamage;

        [SerializeField] private Attribute _attackSpeed;
        [SerializeField] private Attribute _movementSpeed;

        [SerializeField] private Attribute _allDamageTakenReduction;
        [SerializeField] private Attribute _allDamageDoneIncrease;

        [SerializeField] private List<Attribute> _secondaryAttributes;

        public Attribute CriticalChance { get => _criticalChance; }
        public Attribute CriticalDamage { get => _criticalDamage; }

        public void InitializeCharacter(Character character, CharacterTemplate characterTemplate)
        {
            character.Attributes[_level] = new CharacterModifier(characterTemplate.Level);
            character.Attributes[_health] = new CharacterModifier(characterTemplate.Health);
            character.Attributes[_mana] = new CharacterModifier(characterTemplate.Mana);

            character.Attributes[_strength] = new CharacterModifier(characterTemplate.Strength);
            character.Attributes[_intellect] = new CharacterModifier(characterTemplate.Intellect);
            character.Attributes[_dexterity] = new CharacterModifier(characterTemplate.Dexterity);
            character.Attributes[_faith] = new CharacterModifier(characterTemplate.Faith);
            character.Attributes[_power] = new CharacterModifier(characterTemplate.Power);

            character.Attributes[_healthRegen] = new CharacterModifier(characterTemplate.HealthRegen);
            character.Attributes[_manaRegen] = new CharacterModifier(characterTemplate.ManaRegen);

            character.Attributes[_criticalChance] = new CharacterModifier(characterTemplate.CriticalChance);
            character.Attributes[_criticalDamage] = new CharacterModifier(characterTemplate.CriticalDamage);

            character.Attributes[_attackSpeed] = new CharacterModifier(characterTemplate.AttackSpeed);
            character.Attributes[_movementSpeed] = new CharacterModifier(characterTemplate.MovementSpeed);

            character.Attributes[_allDamageTakenReduction] = new CharacterModifier(characterTemplate.AllDamageTakenReduction);
            character.Attributes[_allDamageDoneIncrease] = new CharacterModifier(characterTemplate.AllDamageDoneIncrease);
        }
    }
}