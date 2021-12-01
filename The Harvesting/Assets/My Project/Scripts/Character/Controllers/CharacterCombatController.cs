using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class CharacterCombatController : MonoBehaviour
    {
        protected CharacterCore _core;
        
        protected CombatSettings _combatSettings;
        protected Dictionary<CharacterState, float> _characterStates = new Dictionary<CharacterState, float>();
        protected float[] _characterStateTimers = new float[7];

        protected Dictionary<CharacterState, CharacterStat> _characterStateEffects;

        
        protected float _characterStateCheckTimer;

        public CharacterCore CharacterCore { get => _core; }
        public Dictionary<Attribute, float> Attributes;

        protected virtual void Start()
        {
            SetUpTimers();
        }

        protected virtual void Update()
        {
            HandleTimers();
        }

        protected bool SetUpTimers()
        {
            print("SETUP TIMERS CALLED");
            if(_combatSettings == null)
            {
                return false;
            }

            _characterStateCheckTimer = _combatSettings.CharacterStateCheckRate;

            for (int i = 0; i < _characterStateTimers.Length; i++)
            {
                _characterStateTimers[i] = 0f;
            }

            return true;
        }

        protected void Initiliaze(CombatSettings combatSettings)
        {
            _combatSettings = combatSettings;

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

        protected void ReceiveSkillAction(SkillAction skillAction, Character character)
        {
            
        }
    }
}
