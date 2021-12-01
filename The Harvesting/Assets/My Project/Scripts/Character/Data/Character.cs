using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// Character Class. Contains Character game data.
    /// </summary>
    public abstract class Character
    {
        protected CoreAttributes _coreAttributes;
        protected bool dead = false;
        protected CharacterModifier _level;
        protected CharacterModifier _health;
        protected float _currentHealth;
        protected CharacterModifier _mana;
        protected float _currentMana;

        protected CharacterModifier _strength;
        protected CharacterModifier _intellect;
        protected CharacterModifier _dexterity;
        protected CharacterModifier _faith;
        protected CharacterModifier _power;

        protected CharacterModifier _healthRegen;
        protected CharacterModifier _manaRegen;

        protected CharacterModifier _attackSpeed;
        protected CharacterModifier _movementSpeed;

        protected CharacterModifier _criticalChance;
        protected CharacterModifier _criticalDamage;

        protected CharacterModifier _allDamageTakenReduction;
        protected CharacterModifier _allDamageDoneIncrease;

        protected List<Skill> _abilities = new List<Skill>();
        public List<Skill> Abilities { get => _abilities; }

        protected Dictionary<Attribute, CharacterModifier> _attributes = new Dictionary<Attribute, CharacterModifier>();
        protected Dictionary<SkillAction, SkillActionSource> _statusEffects;

        protected CharacterModifier Level { get => _level; }
        public Dictionary<Attribute, CharacterModifier> Attributes { get => _attributes; }
        public CoreAttributes CoreAttributes { get => _coreAttributes; }

        protected Character(CoreAttributes coreAttributes, CharacterTemplate characterTemplate)
        {
            //coreAttributes.InitializeCharacter(this, characterTemplate);
            _coreAttributes = coreAttributes;

            _attributes[coreAttributes.Level] = new CharacterModifier(characterTemplate.Level, coreAttributes.Level);
            _attributes[coreAttributes.Health] = new CharacterModifier(characterTemplate.Health, coreAttributes.Health);
            _attributes[coreAttributes.Mana] = new CharacterModifier(characterTemplate.Mana, coreAttributes.Mana);

            _attributes[coreAttributes.Strength] = new CharacterModifier(characterTemplate.Strength, coreAttributes.Strength);
            _attributes[coreAttributes.Intellect] = new CharacterModifier(characterTemplate.Intellect, coreAttributes.Intellect);
            _attributes[coreAttributes.Dexterity] = new CharacterModifier(characterTemplate.Dexterity, coreAttributes.Dexterity);
            _attributes[coreAttributes.Faith] = new CharacterModifier(characterTemplate.Faith, coreAttributes.Faith);
            _attributes[coreAttributes.Power] = new CharacterModifier(characterTemplate.Power, coreAttributes.Power);

            _attributes[coreAttributes.HealthRegen] = new CharacterModifier(characterTemplate.HealthRegen, coreAttributes.HealthRegen);
            _attributes[coreAttributes.ManaRegen] = new CharacterModifier(characterTemplate.ManaRegen, coreAttributes.ManaRegen);

            _attributes[coreAttributes.CriticalChance] = new CharacterModifier(characterTemplate.CriticalChance, coreAttributes.CriticalChance);
            _attributes[coreAttributes.CriticalDamage] = new CharacterModifier(characterTemplate.CriticalDamage, coreAttributes.CriticalDamage);

            _attributes[coreAttributes.AttackSpeed] = new CharacterModifier(characterTemplate.AttackSpeed, coreAttributes.AttackSpeed);
            _attributes[coreAttributes.MovementSpeed] = new CharacterModifier(characterTemplate.MovementSpeed, coreAttributes.MovementSpeed);

            _attributes[coreAttributes.AllDamageTakenReduction] = new CharacterModifier(characterTemplate.AllDamageTakenReduction, coreAttributes.AllDamageTakenReduction);
            _attributes[coreAttributes.AllDamageDoneIncrease] = new CharacterModifier(characterTemplate.AllDamageDoneIncrease, coreAttributes.AllDamageDoneIncrease);

            _currentHealth = _attributes[coreAttributes.Health].FinalValue();
            _currentMana = _attributes[coreAttributes.Mana].FinalValue();

            /*
            _level = new CharacterModifier(characterTemplate.Level, coreAttributes.Level);
            _health = new CharacterModifier(characterTemplate.Health, coreAttributes.Health);
            _mana = new CharacterModifier(characterTemplate.Mana, coreAttributes.Mana);


            Debug.Log("Health  :   " + _currentHealth + " / " + _health.FinalValue());
            _strength = new CharacterModifier(characterTemplate.Strength, coreAttributes.Strength);
            _intellect = new CharacterModifier(characterTemplate.Intellect, coreAttributes.Intellect);
            _dexterity = new CharacterModifier(characterTemplate.Dexterity, coreAttributes.Dexterity);
            _faith = new CharacterModifier(characterTemplate.Faith, coreAttributes.Faith);
            _power = new CharacterModifier(characterTemplate.Power, coreAttributes.Power);

            _healthRegen = new CharacterModifier(characterTemplate.HealthRegen, coreAttributes.HealthRegen);
            _manaRegen = new CharacterModifier(characterTemplate.ManaRegen, coreAttributes.ManaRegen);

            _criticalChance = new CharacterModifier(characterTemplate.CriticalChance, coreAttributes.CriticalChance);
            _criticalDamage = new CharacterModifier(characterTemplate.CriticalDamage, coreAttributes.CriticalDamage);

            _attackSpeed = new CharacterModifier(characterTemplate.AttackSpeed, coreAttributes.AttackSpeed);
            _movementSpeed = new CharacterModifier(characterTemplate.MovementSpeed, coreAttributes.MovementSpeed);

            _allDamageTakenReduction = new CharacterModifier(characterTemplate.AllDamageTakenReduction, coreAttributes.AllDamageTakenReduction);
            _allDamageDoneIncrease = new CharacterModifier(characterTemplate.AllDamageDoneIncrease, coreAttributes.AllDamageDoneIncrease);
            */
            
            BoundHealth();
            BoundMana();
        }



        public void ReceiveSkillAction(Character performer, SkillAction skillAction)
        {
           
        }



        public float AttributeValue(Attribute attribute)
        {
            CharacterModifier mod = _attributes[attribute];
            return mod.FinalValue();
        }

        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;
            BoundHealth();
        }



        public void GetHealed(float amount)
        {
            _currentHealth += amount;
            BoundHealth();
        }

        protected void BoundHealth()
        {
            var value = _attributes[_coreAttributes.Health].FinalValue();

            if(_currentHealth > value)
            {
                _currentHealth = value;
            } else if(_currentHealth < 0)
            {
                _currentHealth = 0;
            }
        }

        protected void BoundMana()
        {
            var value = _attributes[_coreAttributes.Mana].FinalValue();

            if (_currentMana > value)
            {
                _currentMana= value;
            }
            else if (_currentMana < 0)
            {
                _currentMana = 0;
            }
        }

        public float HealthPercentage()
        {
            return _currentHealth / _attributes[_coreAttributes.Health].FinalValue();
        }

        public float ManaPercentage()
        {
            return _currentMana / _attributes[_coreAttributes.Mana].FinalValue();
        }

        public bool AddStatusEffect(StatusEffect statusEffect, Character character, SkillAction skillAction)
        {
            SkillActionSource source = new SkillActionSource(character, skillAction);

            return false;
        }

        public void Update()
        {

        }
     
    }
}