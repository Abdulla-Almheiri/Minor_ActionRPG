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
        public CoreAttributes CoreAttributes;
        protected bool dead = false;
        protected int _level;
        protected CharacterModifier _health;
        protected float _currentHealth;
        protected CharacterModifier _mana;
        protected float _currentMana;

        protected CharacterModifier _healthRegen;
        protected CharacterModifier _manaRegen;

        protected CharacterModifier _attackSpeed;
        protected CharacterModifier _movementSpeed;

        protected CharacterModifier _criticalChance;
        protected CharacterModifier _criticalDamage;

        protected CharacterModifier _damageTakenReduction;
        protected CharacterModifier _damageDoneIncrease;


        public Dictionary<Attribute, CharacterModifier> Attributes;
        protected Dictionary<SkillAction, StatusEffectSource> _statusEffects;
        protected Character(CharacterCore characterCore, CoreAttributes coreAttributes, CharacterTemplate characterTemplate)
        {
            coreAttributes.InitializeCharacter(this, characterTemplate);
        }
        
 
       
        public void ReceiveSkillAction(Character performer, SkillAction skillAction)
        {
           
        }



        public float AttributeValue(Attribute attribute)
        {
            CharacterModifier mod = Attributes[attribute];
            return mod.FinalValue();
        }

        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;
            BoundHealth();
        }

        public bool Equip(Item item)
        {
            return false;
        }

        protected void GetHealed(float amount)
        {
            _currentHealth += amount;
            BoundHealth();
        }

        protected void BoundHealth()
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

        protected void BoundMana()
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

        public bool AddStatusEffect(StatusEffect statusEffect, Character character, SkillAction skillAction)
        {
            StatusEffectSource source = new StatusEffectSource(character, skillAction);

            return false;
        }

        public void Update()
        {

        }
     
    }
}