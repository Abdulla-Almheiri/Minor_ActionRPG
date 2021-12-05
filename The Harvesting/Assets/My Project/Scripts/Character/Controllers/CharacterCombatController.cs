using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class CharacterCombatController : MonoBehaviour, ICharacterCombatController
    {
        public bool IsAlive { get; protected set; } = true;
        public float CurrentHealth { get; protected set; }
        public float CurrentMana { get; protected set; }
        public float Size { get; protected set; } = 1f;
        public ICharacterCore Core { get; protected set; }
        public ICharacterData CharacterData { get; protected set; }
        public CombatSettings CombatSettings { get; protected set; }


        protected Dictionary<CharacterState, float> _characterStates = new Dictionary<CharacterState, float>();
        protected float[] _characterStateTimers = new float[7];

        protected Dictionary<CharacterState, CharacterStat> _characterStateEffects;

        
        protected float _characterStateCheckTimer;

        private float _healthRegenTickTimer;
        private float _manaRegenTickTimer;

        public Dictionary<Attribute, float> Attributes;


        protected virtual void Update()
        {
            
            HandleTimers();
            HandleRegen();
        }

        protected bool SetUpTimers()
        {
            //print("SETUP TIMERS CALLED");
            if(CombatSettings == null)
            {
                return false;
            }

            _characterStateCheckTimer = CombatSettings.CharacterStateCheckRate;

            for (int i = 0; i < _characterStateTimers.Length; i++)
            {
                _characterStateTimers[i] = 0f;
            }

            _healthRegenTickTimer = Core.GameManager.CoreAttributesTemplate.HealthRegenTickRate;
            _manaRegenTickTimer = Core.GameManager.CoreAttributesTemplate.ManaRegenTickRate;

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
                
                float damageAmount = (skillAction.Modifier.Value) + skillAction.Modifier.Percentage / 100f * performer.CharacterData.CoreAttributes[skillAction.Modifier.Attribute].FinalValue();
                if (damageAmount <= 0f)
                {
                    damageAmount = 0f;
                }
                //Critical Damage Check
                if (Random.Range(0, 100) <= performer.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.CriticalChance].FinalValue())
                {
                    var critMulti = Core.GameManager.CoreAttributesTemplate.CriticalMultiplier + (performer.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.CriticalDamage].FinalValue() / 100f);
                    damageAmount *= critMulti;
                    isCritical = true;
                }

                if (skillAction.Element != null && Core.CharacterData.ResistanceAttributes.TryGetValue(skillAction.Element, out CharacterModifier charModifier) == true)
                {
                    damageAmount -= (charModifier.FinalValue());
                }


                skillActionData = new SkillActionEventData(true, Mathf.Max(1f, damageAmount), isCritical, false, skillAction.Element);
                TakeDamage(Mathf.Max(1f, damageAmount), isCritical);

            }
            else if (skillAction.Type == Core.GameManager.CoreAttributesTemplate.SkillActionHeal)
            {
                Debug.Log("Healing spell checked");
                float healAmount = (skillAction.Modifier.Value) + skillAction.Modifier.Percentage / 100f * Core.CharacterData.CoreAttributes[skillAction.Modifier.Attribute].FinalValue();

                //Critical Heal Check
                if (Random.Range(0, 100) <= performer.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.CriticalChance].FinalValue())
                {
                    var critMulti = Core.GameManager.CoreAttributesTemplate.CriticalMultiplier + (performer.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.CriticalDamage].FinalValue() / 100f);
                    healAmount *= critMulti;
                    //healAmount += performer.PrimaryAttributes[_coreAttributesTemplate.CriticalDamage].FinalValue();
                    isCritical = true;
                }

                skillActionData = new SkillActionEventData(true, healAmount, isCritical, false, skillAction.Element);
                GetHealed(healAmount, isCritical);
            }
            else if (skillAction.Type == Core.GameManager.CoreAttributesTemplate.SkillActionStatusEffect)
            {
                AddStatusEffect(skillAction.CharacterStatusEffect, skillAction.Modifier.Duration, performer, skillAction);
                skillActionData = new SkillActionEventData(false, 0f, false, false, skillAction.Element);
            }
            else
            {
                skillActionData = new SkillActionEventData(false, 0f, isCritical, false, skillAction.Element);
            }



        }


        public virtual void LevelUp(int newLevel)
        {
            var attribute = Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Level];
            if (newLevel <= attribute.FinalValue())
            {
                return;
            }

            attribute.BaseAdd = newLevel;

        }

        public float AttributeValue(Attribute attribute)
        {
            CharacterModifier mod = Core.CharacterData.CoreAttributes[attribute];
            return mod.FinalValue();
        }

        protected void TakeDamage(float amount, bool isCritical)
        {
            CurrentHealth -= amount;
            BoundHealth();
            bool isHarm = false;
            if(MyUtility.CompareLayers(Core.GameObject.layer, Core.GameManager.PlayerLayer))
            {
                isHarm = true;
            }
            Core.GameManager.UIController.CombatTextManager.PlaceDamageText(Core.MovementController.Transform.position, amount, 2f, isCritical, false, isHarm);
        }

        public void IncurManaCost(Skill skill)
        {
            CurrentMana -= skill.ManaCost;
            BoundMana();

        }

        protected void GetHealed(float amount, bool isCritical)
        {
            Debug.Log("HEALED");
            CurrentHealth += amount;
            BoundHealth();
            Core.GameManager.UIController.CombatTextManager.PlaceDamageText(Core.MovementController.Transform.position, amount, 2f, isCritical, true, false);
        }

        protected void BoundHealth()
        {
            var value = Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Health].FinalValue();

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
            var value = Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Mana].FinalValue();

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
            
            BoundHealth();
            return CurrentHealth / Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Health].FinalValue();
        }

        public float ManaPercentage()
        {
            
            BoundMana();
            return CurrentMana / Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Mana].FinalValue();
        }

        public bool AddStatusEffect(CharacterState statusEffect, float duration, ICharacterCore character, SkillAction skillAction)
        {
            AddCharacterState(statusEffect, duration);

            return true;
        }

        protected virtual void UpdateStats()
        {
            Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Health].BaseAdd += Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Strength].FinalValue() * Core.GameManager.CoreAttributesTemplate.StrengthToHealth;
            CurrentHealth = Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Health].FinalValue();

            Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Mana].BaseAdd += Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Intellect].FinalValue() * Core.GameManager.CoreAttributesTemplate.IntellectToMaximumMana;
            CurrentMana = Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Mana].FinalValue();

            Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.HealthRegen].BaseAdd += Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Faith].FinalValue() * Core.GameManager.CoreAttributesTemplate.FaithToHealthRegen;
            Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.ManaRegen].BaseAdd += Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Faith].FinalValue() * Core.GameManager.CoreAttributesTemplate.FaithToManaRegen;

            Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.CriticalDamage].BaseAdd += Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.Intellect].FinalValue() * Core.GameManager.CoreAttributesTemplate.IntellectToCriticalDamage;

            BoundHealth();
            BoundMana();
        }


        public void Initialize(ICharacterCore core)
        {
            Core = core;
            CombatSettings = Core.GameManager.CombatSettings;
            Size = Core.Template.Size;
            SetUpTimers();
            UpdateStats();
        }

        public bool IsWithinMeleeRange(ICharacterCore character)
        {
            //OPTIMIZE CALCULATIONS HERE
            if(character == null)
            {
                return false;
            }

            var meleeRange = (Core.GameManager.CombatSettings.DefaultMeleeRange * Core.CombatController.Size) + (character.GameManager.CombatSettings.DefaultMeleeRange * character.CombatController.Size);

            if (Vector3.Distance(Core.MovementController.Transform.position, character.MovementController.Transform.position) <= meleeRange)
            {
                
                return true;
            } else
            {
                return false;
            }
        }

        protected void HandleRegen()
        {
            _manaRegenTickTimer -= Time.deltaTime;
            _healthRegenTickTimer -= Time.deltaTime;

            if (_manaRegenTickTimer < 0f)
            {
                if (ManaPercentage() < (1f - MyMaths.NearZero))
                {
                    CurrentMana += Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.ManaRegen].FinalValue();
                    BoundMana();
                }

                _manaRegenTickTimer = Core.GameManager.CoreAttributesTemplate.ManaRegenTickRate;
            }

            if (_healthRegenTickTimer < 0f)
            {
                if (HealthPercentage() < (1f - MyMaths.NearZero))
                {
                    CurrentHealth += Core.CharacterData.CoreAttributes[Core.GameManager.CoreAttributesTemplate.HealthRegen].FinalValue();
                    BoundHealth();
                }
                _healthRegenTickTimer = Core.GameManager.CoreAttributesTemplate.HealthRegenTickRate;
            }
        }

        public void RefundManaCost(Skill skill)
        {
            CurrentMana += skill.ManaCost;
            BoundMana();
        }

        public bool HasManaForSkill(Skill skill)
        {
            if (CurrentMana > skill.ManaCost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
