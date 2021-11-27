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
        private bool dead = false;
        private int _level;
        public CharacterModifier _health;
        private float _currentHealth;
        public CharacterModifier _mana;
        private float _currentMana;

        private CharacterModifier _healthRegen;
        private CharacterModifier _manaRegen;

        private CharacterModifier _attackSpeed;
        private CharacterModifier _movementSpeed;

        private CharacterModifier _criticalChance;
        private CharacterModifier _criticalDamage;

        private CharacterModifier _damageTakenReduction;
        private CharacterModifier _damageDoneIncrease;


        public Dictionary<Attribute, CharacterModifier> Attributes;

        
        protected Character()
        {

        }
        
       public Character(CharacterTemplate characterTemplate)
        {
            _health.Base.FlatValue = characterTemplate.Health;
            _mana.Base.FlatValue = characterTemplate.Mana;

            _healthRegen.Base.FlatValue = characterTemplate.HealthRegen;
            _manaRegen.Base.FlatValue = characterTemplate.ManaRegen;

            _attackSpeed.Base.FlatValue = characterTemplate.AttackSpeed;
            _movementSpeed.Base.FlatValue = characterTemplate.MovementSpeed;

            _criticalChance.Base.FlatValue = characterTemplate.CriticalChance;
            _criticalDamage.Base.FlatValue = characterTemplate.CriticalDamage;

            _damageTakenReduction.Base.FlatValue = characterTemplate.DamageTakenReduction;
            _damageDoneIncrease.Base.FlatValue = characterTemplate.DamageDoneIncrease;

            foreach(AttributeFloat mod in characterTemplate.Attributes)
            {
                Attributes[mod.Attribute] = new CharacterModifier(mod.Value);
            }

            BoundHealth();
            BoundMana();
        }
       
        public void ReceiveSkillAction(Character performer, SkillAction skillAction)
        {
           
        }

        public Character(CoreAttributes coreAttributes, CharacterTemplate characterTemplate)
        {
            foreach(Attribute attribute in coreAttributes.AdditionalAttributes)
            {
                Attributes[attribute] = new CharacterModifier(0);
            }
        }

        public float Attribute(Attribute attribute)
        {
            CharacterModifier mod = Attributes[attribute];
            return mod.FinalValue();
        }

        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;
            BoundHealth();
        }

        private void GetHealed(float amount)
        {
            _currentHealth += amount;
            BoundHealth();
        }

        private void BoundHealth()
        {
            var value = _health.FinalValue();

            if(_currentHealth > value)
            {
                _currentHealth = value;
            } else if(_currentHealth < 0)
            {
                _currentHealth = 0;
            }
        }

        private void BoundMana()
        {
            var value = _mana.FinalValue();

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
            return _currentHealth / _health.FinalValue();
        }
     
    }
}