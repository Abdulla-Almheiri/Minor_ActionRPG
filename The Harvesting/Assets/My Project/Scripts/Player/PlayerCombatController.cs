using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerCombatController : MonoBehaviour
    {
        public float StateCheckRate = 0.2f;
        private float stateCheckTimer = 0f;
        private PlayerCore playerCore;
        private PlayerAnimationController animationController;
        private PlayerSkillController skillController;
        public CharacterState TestState1;
        public float TestDuration1;
        public CharacterState TestState2;
        public float TestDuration2;

        private CharacterState currentState;
        private float[] currentStateDurations;
        private float[] timers;

        private List<CharacterState> characterStates = new List<CharacterState>();
        private float[] stateDurations;

        void Start()
        {
            currentState = ScriptableObject.CreateInstance<CharacterState>();
            currentStateDurations = new float[7];
            timers = new float[7];

            playerCore = GetComponent<PlayerCore>();
            animationController = playerCore.GetComponent<PlayerAnimationController>();
            skillController = playerCore.GetComponent<PlayerSkillController>();

            stateDurations = new float[32];

            stateCheckTimer = StateCheckRate;
        }

      
        void Update()
        {

            // TESTING

            if(Input.GetKeyDown(KeyCode.S))
            {
                AddState2(TestState1, TestDuration1);
                //currentState.PrintDebugValues();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                currentState = CurrentCharacterState();
                currentState.PrintDebugValues();

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                AddState2(TestState2, TestDuration2);

            }


           // HandleStates();
            HandleStates2();
        }

        /// <summary>
        /// Attempts to add a CharacterState or update it if it already exists. Returns true if state is added or updated, false if it fails.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="duration"></param>
        public bool AddState(CharacterState state, float duration)
        {
            int index = characterStates.IndexOf(state);
            if(index >= stateDurations.Length-1)
            {
                return false;
            }

            if (index != -1)
            {
                if (stateDurations[index] < duration)
                {
                    stateDurations[index] = duration;
                }
                UpdateCharacterState(state, duration);
                return true;
            }

            characterStates.Add(state);
            stateDurations[index+1] = duration;
            UpdateCharacterState(state, duration);
            Debug.Log("State " + state.name + " with a duration of " + stateDurations[index+1]);
            return true;

        }

        /// <summary>
        /// Checks if a CharacterState is currently active and returns its index. Outputs duration.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public int CheckStateExists(CharacterState state, out float duration)
        {
            int index = characterStates.IndexOf(state);
            if(index == -1)
            {
                duration = 0;
                return index;
            }
            duration = stateDurations[index];
            return index;
        }


        /// <summary>
        /// Attempts to change CharacterState duration. Returns true if successful, otherwise returns false.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="newDuration"></param>
        /// <returns></returns>
        public bool ChangeStateDuration(CharacterState state, float newDuration)
        {
            int index = CheckStateExists(state, out _);
            if (index != -1)
            {
                stateDurations[index] = newDuration;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Handle CharacterStates. Runs every frame.
        /// </summary>
        private void HandleStates()
        {
            stateCheckTimer -= Time.deltaTime;
            int i = 0;
            if(stateCheckTimer <=0)
            {
                foreach(var item in characterStates)
                {
                    stateDurations[i] -= (StateCheckRate - stateCheckTimer);


                    if(stateDurations[i] < 0)
                    {
                        stateDurations[i] = 0;
                    }

                    //Debug.Log("UPDATED : State " + item.name + " with remaining duration of " + stateDurations[i]);
                    i++;

                }
                stateCheckTimer = StateCheckRate;
            }
        }

        /// <summary>
        /// Returns the current CharacterState.
        /// </summary>
        /// <returns></returns>
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


        private void UpdateCharacterState(CharacterState newState, float duration)
        {
            var array = newState.GetArray();
            for(int i = 0; i< currentStateDurations.Length; i++)
            {   
                if(array[i] && currentStateDurations[i] < duration)
                {
                    currentStateDurations[i] = duration;

                }
            }

        }

        public void AddState2(CharacterState state, float duration)
        {
            timers[0] = (timers[0] < duration && state.CanMove == false) ? duration : timers[0];
            timers[1] = (timers[1] < duration && state.CanInteract == false) ? duration : timers[1];
            timers[2] = (timers[2] < duration && state.CanAttack == false) ? duration : timers[2];
            timers[3] = (timers[3] < duration && state.CanCast == false) ? duration : timers[3];
            timers[4] = (timers[4] < duration) ? duration : timers[4];
            timers[5] = (timers[5] < duration) ? duration : timers[5];
            timers[6] = (timers[6] < duration) ? duration : timers[6];

            Debug.Log("State " + state.name + " with a duration of " + duration);
        }

        public void HandleStates2()
        {
            for(int i = 0; i< timers.Length; i++)
            {
                if (timers[i] > 0)
                {
                    timers[i] -= Time.deltaTime;
                    Debug.Log("TIMERS    :   " + timers[i]);
                }
            }
        }
    }
}