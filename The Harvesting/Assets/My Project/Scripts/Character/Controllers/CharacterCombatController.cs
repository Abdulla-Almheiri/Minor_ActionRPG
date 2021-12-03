using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class CharacterCombatController : MonoBehaviour, ICharacterCombatController
    {
        public bool IsAlive { get; protected set; }
        public float CurrentHealth { get; protected set; }
        public float CurrentMana { get; protected set; }

        public ICharacterCore Core { get; protected set; }
        public ICharacterData CharacterData { get; protected set; }
        public CombatSettings CombatSettings { get; protected set; }


        protected Dictionary<CharacterState, float> _characterStates = new Dictionary<CharacterState, float>();
        protected float[] _characterStateTimers = new float[7];

        protected Dictionary<CharacterState, CharacterStat> _characterStateEffects;

        
        protected float _characterStateCheckTimer;

        public Dictionary<Attribute, float> Attributes;


        protected virtual void Update()
        {
            HandleTimers();
        }

        protected bool SetUpTimers()
        {
            print("SETUP TIMERS CALLED");
            if(CombatSettings == null)
            {
                return false;
            }

            _characterStateCheckTimer = CombatSettings.CharacterStateCheckRate;

            for (int i = 0; i < _characterStateTimers.Length; i++)
            {
                _characterStateTimers[i] = 0f;
            }

            return true;
        }

        protected void HandleCombat()
        {

        }

        public bool AddCharacterState(CharacterState characterState, float rawDuration)
        {
            if(_characterStates.TryGetValue(characterState, out float value) == true && value >= rawDuration)
            {
                return false;
            } else
            {
                if (IsCharacterStatePossible(characterState, rawDuration, out float newDuration) == true)
                {
                    _characterStates[characterState] = newDuration;
                    UpdateTimersAdd(characterState, newDuration);
                    return true;
                } 
            }
            return false;
        }

        protected virtual bool IsCharacterStatePossible(CharacterState characterState, float duration, out float newDuration)
        {
            newDuration = duration;
            return true;
        }

        protected virtual float CharacterStateDuration(CharacterState characterState)
        {
            _characterStates.TryGetValue(characterState, out float duration);
            return duration;
        }

        public bool CanMove()
        {
            return _characterStateTimers[0] <= Time.deltaTime;
        }

        public bool CanInteract()
        {
            return _characterStateTimers[1] <= Time.deltaTime;
        }

        public bool CanAttack()
        {
            return _characterStateTimers[2] <= Time.deltaTime;
        }

        public bool CanCast()
        {
            return _characterStateTimers[3] <= Time.deltaTime;
        }

        public bool CanBlock()
        {
            return _characterStateTimers[4] <= Time.deltaTime;
        }

        public bool CanBeDamaged()
        {
            return _characterStateTimers[5] <= Time.deltaTime;
        }
        public bool CanBeHealed()
        {
            return _characterStateTimers[6] <= Time.deltaTime;
        }

        protected void UpdateTimersAdd(CharacterState characterState, float duration)
        {
            _characterStateTimers[0] = (_characterStateTimers[0] < duration && characterState.CanMove == false) ? duration : _characterStateTimers[0];
            _characterStateTimers[1] = (_characterStateTimers[1] < duration && characterState.CanInteract == false) ? duration : _characterStateTimers[1];
            _characterStateTimers[2] = (_characterStateTimers[2] < duration && characterState.CanAttack == false) ? duration : _characterStateTimers[2];
            _characterStateTimers[3] = (_characterStateTimers[3] < duration && characterState.CanCast == false) ? duration : _characterStateTimers[3];
            _characterStateTimers[4] = (_characterStateTimers[4] < duration && characterState.CanBlock == false) ? duration : _characterStateTimers[4];
            _characterStateTimers[5] = (_characterStateTimers[5] < duration && characterState.CanTakeDamage == false) ? duration : _characterStateTimers[5];
            _characterStateTimers[6] = (_characterStateTimers[6] < duration && characterState.CanBeHealed == false) ? duration : _characterStateTimers[6];
        }

        //Optimize HERE
        protected void UpdateTimers()
        {
            foreach(CharacterState state in _characterStates.Keys)
            {
                UpdateTimersAdd(state, _characterStates[state]);
            }
        }

        protected void HandleTimers()
        {
            for (int i = 0; i < _characterStateTimers.Length; i++)
            {
                if (_characterStateTimers[i] > 0)
                {
                    _characterStateTimers[i] -= Time.deltaTime;
                }
            }
        }

        protected void RemoveAllStatesOfType(CharacterState characterState)
        {
            _characterStates[characterState] = 0f;
        }


        public void ReceiveSkillAction(SkillAction skillAction, ICharacterCore performer, out SkillActionEventData skillActionData)
        {
            //skillActionData = new SkillActionEventData(false, 0f, false, false, null);

            bool isCritical = false;
            if (skillAction.Type == Core.GameManager.CoreAttributesTemplate.SkillActionDamage)
            {
                float damageAmount = (skillAction.Modifier.Value) + (100f + skillAction.Modifier.Percentage / 100f) * performer.Data.CoreAttributes[skillAction.Modifier.Attribute].FinalValue();
                if (damageAmount <= 0f)
                {
                    damageAmount = 0f;
                }
                //Critical Damage Check
                if (Random.Range(0, 100) <= performer.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.CriticalChance].FinalValue())
                {
                    damageAmount *= Core.GameManager.CoreAttributesTemplate.CriticalMultiplier;
                    damageAmount += performer.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.CriticalDamage].FinalValue();
                    isCritical = true;
                }

                if (Core.Data.ResistanceAttributes.TryGetValue(skillAction.Element, out CharacterModifier charModifier) == true)
                {
                    damageAmount -= (charModifier.FinalValue());
                }


                skillActionData = new SkillActionEventData(true, Mathf.Max(1f, damageAmount), isCritical, false, skillAction.Element);
                TakeDamage(Mathf.Max(1f, damageAmount));

            }
            else if (skillAction.Type == Core.GameManager.CoreAttributesTemplate.SkillActionHeal)
            {
                float healAmount = (skillAction.Modifier.Value) + (100f + skillAction.Modifier.Percentage / 100f) * Core.Data.CoreAttributes[skillAction.Modifier.Attribute].FinalValue();

                //Critical Heal Check
                if (Random.Range(0, 100) <= performer.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.CriticalChance].FinalValue())
                {
                    healAmount *= Core.GameManager.CoreAttributesTemplate.CriticalMultiplier;
                    //healAmount += performer.PrimaryAttributes[_coreAttributesTemplate.CriticalDamage].FinalValue();
                    isCritical = true;
                }

                skillActionData = new SkillActionEventData(true, healAmount, isCritical, false, skillAction.Element);
                GetHealed(healAmount);
            }
            else if (skillAction.Type == Core.GameManager.CoreAttributesTemplate.SkillActionStatusEffect)
            {
                //AddStatusEffect(skillAction.CharacterStatusEffect, skillAction.Modifier.Duration, performer, skillAction);
                skillActionData = new SkillActionEventData(false, 0f, false, false, skillAction.Element);
            }
            else
            {
                skillActionData = new SkillActionEventData(false, 0f, isCritical, false, skillAction.Element);
            }



        }


        public virtual void LevelUp(int newLevel)
        {
            var attribute = Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Level];
            if (newLevel <= attribute.FinalValue())
            {
                return;
            }

            attribute.BaseAdd = newLevel;

        }

        public float AttributeValue(Attribute attribute)
        {
            CharacterModifier mod = Core.Data.CoreAttributes[attribute];
            return mod.FinalValue();
        }

        protected void TakeDamage(float amount)
        {
            CurrentHealth -= amount;
            BoundHealth();
        }



        protected void GetHealed(float amount)
        {
            CurrentHealth += amount;
            BoundHealth();
        }

        protected void BoundHealth()
        {
            var value = Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Health].FinalValue();

            if (CurrentHealth > value)
            {
                CurrentHealth = value;
            }
            else if (CurrentHealth < 0f)
            {
                CurrentHealth = 0f;
            }
        }

        protected void BoundMana()
        {
            var value = Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Mana].FinalValue();

            if (CurrentMana > value)
            {
                CurrentMana= value;
            }
            else if (CurrentMana < 0f)
            {
                CurrentMana = 0f;
            }
        }

        public float HealthPercentage()
        {
            return CurrentHealth / Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Health].FinalValue();
        }

        public float ManaPercentage()
        {
            return CurrentMana / Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Mana].FinalValue();
        }

        public bool AddStatusEffect(CharacterState statusEffect, float duration, CharacterData character, SkillAction skillAction)
        {
            SkillActionSource source = new SkillActionSource(character, skillAction);

            return false;
        }

        protected virtual void UpdateStats()
        {
            Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Health].BaseAdd += Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Strength].FinalValue() * Core.GameManager.CoreAttributesTemplate.StrengthToHealth;
            CurrentHealth = Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Health].FinalValue();

            Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Mana].BaseAdd += Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Mana].FinalValue() * Core.GameManager.CoreAttributesTemplate.IntellectToMaximumMana;
            CurrentMana = Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Mana].FinalValue();

            Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.HealthRegen].BaseAdd += Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Faith].FinalValue() * Core.GameManager.CoreAttributesTemplate.FaithToHealthRegen;
            Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.ManaRegen].BaseAdd += Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Faith].FinalValue() * Core.GameManager.CoreAttributesTemplate.FaithToManaRegen;

            Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.CriticalDamage].BaseAdd += Core.Data.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Intellect].FinalValue() * Core.GameManager.CoreAttributesTemplate.IntellectToCriticalDamage;

            BoundHealth();
            BoundMana();
        }


        public void Initialize(ICharacterCore core)
        {
            Core = core;
            CombatSettings = Core.GameManager.CombatSettings;
            SetUpTimers();
        }
    }
}
