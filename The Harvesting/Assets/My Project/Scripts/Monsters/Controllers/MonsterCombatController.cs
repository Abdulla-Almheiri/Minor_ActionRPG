using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class MonsterCombatController : MonoBehaviour
    {
        public CharacterStats MonsterData;
        public MonsterCore MonsterCore;
        public MonsterAI MonsterAI;
        public MonsterAnimationController AnimationController;
        public MonsterMovementController MovementController;
        public MonsterSkillController SkillController;
        private CharacterState currentState;
        [HideInInspector]
        public List<StatusEffect> StatusEffects = new List<StatusEffect>();
        private float[] currentStateDurations;
        private float[] timers;
        private float[] statusEffectTimers;
        // Start is called before the first frame update
        void Start()
        {
            currentState = ScriptableObject.CreateInstance<CharacterState>();
            currentStateDurations = new float[7];
            timers = new float[7];
            statusEffectTimers = new float[64];

            AnimationController = GetComponent<MonsterAnimationController>();
            MovementController = GetComponent<MonsterMovementController>();
            SkillController = GetComponent<MonsterSkillController>();
        }

        // Update is called once per frame
        void Update()
        {
            HandleStates();
            if (CanMove(CurrentCharacterState()))
            {
                MovementController.MoveToPoint(MonsterAI.CalculatedDestination(MonsterCore.PlayerCore, MonsterCore));
            }


           
        }

        public bool Stunned(CharacterState state)
        {
            return (!state.CanAttack && !state.CanInteract && !state.CanCast && !state.CanMove);
        }

        public bool Dead(CharacterState state)
        {
            return (!state.CanAttack && !state.CanInteract && !state.CanCast && !state.CanMove && !state.CanBlock && !state.CanTakeDamage && !state.CanBeHealed);
        }
        public bool CanMove(CharacterState state)
        {
            return state.CanMove;
        }    
        public CharacterState CurrentCharacterState()
        {
            currentState.CanMove = (timers[0] <= 0) ? true : false;
            currentState.CanInteract = (timers[1] <= 0) ? true : false;
            currentState.CanAttack = (timers[2] <= 0) ? true : false;
            currentState.CanCast = (timers[3] <= 0) ? true : false;
            currentState.CanBlock = (timers[4] <= 0) ? true : false;
            currentState.CanTakeDamage = (timers[5] <= 0) ? true : false;
            currentState.CanBeHealed = (timers[6] <= 0) ? true : false;

            return currentState;
        }



        public void AddState(CharacterState state, float duration)
        {
            timers[0] = (timers[0] < duration && state.CanMove == false) ? duration : timers[0];
            timers[1] = (timers[1] < duration && state.CanInteract == false) ? duration : timers[1];
            timers[2] = (timers[2] < duration && state.CanAttack == false) ? duration : timers[2];
            timers[3] = (timers[3] < duration && state.CanCast == false) ? duration : timers[3];
            timers[4] = (timers[4] < duration && state.CanBlock == false) ? duration : timers[4];
            timers[5] = (timers[5] < duration && state.CanTakeDamage == false) ? duration : timers[5];
            timers[6] = (timers[6] < duration && state.CanBeHealed == false) ? duration : timers[6];

            Debug.Log("State " + state.name + " with a duration of " + duration);
        }

        public void HandleStates()
        {
            for (int i = 0; i < timers.Length; i++)
            {
                if (timers[i] > 0)
                {
                    timers[i] -= Time.deltaTime;
                    //Debug.Log("TIMERS    :   " + timers[i]);
                }
            }
        }

        public void AddStatusEffect(StatusEffect statusEffect)
        {
            StatusEffects.Add(statusEffect);
            statusEffectTimers[StatusEffects.Count - 1] = statusEffect.Modifier.Duration;
        }

        private void HandleStatusEffects()
        {

        }
    }
}