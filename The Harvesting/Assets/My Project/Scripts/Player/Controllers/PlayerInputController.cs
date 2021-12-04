using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(PlayerUIController))]
    [RequireComponent(typeof(PlayerSkillController))]

    public class PlayerInputController : CharacterInputController, IPlayerInputController
    {

        public new IPlayerCore Core { get; protected set; }

        private void Update()
        {
            HandleInput();
            
            //TEST
            if(Input.GetKeyDown(KeyCode.Q))
            {
                //Core.CombatController.TakeDamage(5f);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                //Core.CombatController.GetHealed(5f);
            }
            //TEST
        }
        private void HandleInput()
        {
            WaitForMouseClickToMove();
            HandleUIInput();
            HandleSkillInput();
        }

        private void WaitForMouseClickToMove()
        {
            if (Input.GetMouseButton(0))
            {
                Core.MovementController.MoveToMousePosition();
            }
        }

        private void HandleUIInput()
        {
            if (Input.GetKeyDown(InputKeyData.CharacterScreen))
            {
                Core.UIController.ToggleCharacterScreen();
            }
        }

        private void HandleSkillInput()
        {
            for(int i = 0;  i < Mathf.Min(InputKeyData.AbilityInputKeyList.Length, Core.SkillController.Abilities.Count);  i++ )
            {
                if (Input.GetKeyDown(InputKeyData.AbilityInputKeyList[i]))
                {
                    Core.SkillController.ActivateSkill(Core.SkillController.Abilities[i]);
                }
            }
        }

        public void Initialize(IPlayerCore core, InputKeyData inputKeyData)
        {
            Core = core;
            InputKeyData = inputKeyData;
        }
    }
}