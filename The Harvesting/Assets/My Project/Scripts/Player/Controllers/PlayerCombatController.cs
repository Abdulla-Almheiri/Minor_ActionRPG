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
        private PlayerCore _playerCore;
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

        private void Awake()
        {
            _playerCore = GetComponent<PlayerCore>();
        }
        void Start()
        {
            currentState = ScriptableObject.CreateInstance<CharacterState>();
            currentStateDurations = new float[7];
            timers = new float[7];


            //animationController = _playerCore.GetComponent<PlayerAnimationController>();
           // skillController = _playerCore.GetComponent<PlayerSkillController>();

            stateDurations = new float[32];

            stateCheckTimer = StateCheckRate;
        }

      
        void Update()
        {

            // TESTING

            if(Input.GetKeyDown(KeyCode.S))
            {
                AddState(TestState1, TestDuration1);
                //currentState.PrintDebugValues();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                currentState = CurrentCharacterState();
                currentState.PrintDebugValues();

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                AddState(TestState2, TestDuration2);

            }


           // HandleStates();
            HandleStates();
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