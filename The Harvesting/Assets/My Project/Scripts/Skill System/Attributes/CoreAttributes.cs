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
        public Attribute Level { get => _level; set => _level = value; }
        public Attribute ExperiencePoints { get => _experiencePoints; set => _experiencePoints = value; }
        public Attribute Health { get => _health; set => _health = value; }
        public Attribute Mana { get => _mana; set => _mana = value; }
        public Attribute HealthRegen { get => _healthRegen; set => _healthRegen = value; }
        public Attribute ManaRegen { get => _manaRegen; set => _manaRegen = value; }
        public Attribute Strength { get => _strength; set => _strength = value; }
        public Attribute Intellect { get => _intellect; set => _intellect = value; }
        public Attribute Dexterity { get => _dexterity; set => _dexterity = value; }
        public Attribute Faith { get => _faith; set => _faith = value; }
        public Attribute Power { get => _power; set => _power = value; }
        public Attribute AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }
        public Attribute MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }
        public Attribute AllDamageTakenReduction { get => _allDamageTakenReduction; set => _allDamageTakenReduction = value; }
        public Attribute AllDamageDoneIncrease { get => _allDamageDoneIncrease; set => _allDamageDoneIncrease = value; }
        public List<Attribute> SecondaryAttributes { get => _secondaryAttributes; set => _secondaryAttributes = value; }

        /*public void InitializeCharacter(Character character, CharacterTemplate characterTemplate)
        {
            character._attributes[_level] = new CharacterModifier(characterTemplate.Level);
            character._attributes[_health] = new CharacterModifier(characterTemplate.Health);
            character._attributes[_mana] = new CharacterModifier(characterTemplate.Mana);

            character._attributes[_strength] = new CharacterModifier(characterTemplate.Strength);
            character._attributes[_intellect] = new CharacterModifier(characterTemplate.Intellect);
            character._attributes[_dexterity] = new CharacterModifier(characterTemplate.Dexterity);
            character._attributes[_faith] = new CharacterModifier(characterTemplate.Faith);
            character._attributes[_power] = new CharacterModifier(characterTemplate.Power);

            character._attributes[_healthRegen] = new CharacterModifier(characterTemplate.HealthRegen);
            character._attributes[_manaRegen] = new CharacterModifier(characterTemplate.ManaRegen);

            character._attributes[_criticalChance] = new CharacterModifier(characterTemplate.CriticalChance);
            character._attributes[_criticalDamage] = new CharacterModifier(characterTemplate.CriticalDamage);

            character._attributes[_attackSpeed] = new CharacterModifier(characterTemplate.AttackSpeed);
            character._attributes[_movementSpeed] = new CharacterModifier(characterTemplate.MovementSpeed);

            character._attributes[_allDamageTakenReduction] = new CharacterModifier(characterTemplate.AllDamageTakenReduction);
            character._attributes[_allDamageDoneIncrease] = new CharacterModifier(characterTemplate.AllDamageDoneIncrease);
        }*/
    }
}