using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(PlayerUIController))]
    [RequireComponent(typeof(PlayerSkillController))]

    public class PlayerInputController : MonoBehaviour
    {
        private PlayerCore _playerCore;
        [SerializeField] private InputKeyData _inputKeyData;

        private void Start()
        {
            Initialize(null);
        }

        private void Update()
        {
            HandleInput();

            //TEST
            if(Input.GetKeyDown(KeyCode.Q))
            {
                _playerCore.Data.TakeDamage(5f);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _playerCore.Data.GetHealed(5f);
            }
            //TEST
        }
        private void HandleInput()
        {
            WaitForMouseClickToMove();
            HandleUIInput();
            HandleSkillInput();
        }

        public void Initialize(PlayerCore playerCore)
        {
            _playerCore = playerCore ?? GetComponent<PlayerCore>();
        }

        private void WaitForMouseClickToMove()
        {
            if (Input.GetMouseButton(0))
            {
                _playerCore.MovementController.MoveToMousePosition();
            }
        }

        private void HandleUIInput()
        {
            if (Input.GetKeyDown(_inputKeyData.CharacterScreen))
            {
                _playerCore.UIController.ToggleCharacterScreen();
            }
        }

        private void HandleSkillInput()
        {
            for(int i = 0;  i < Mathf.Min(_inputKeyData.AbilityInputKeyList.Length, _playerCore.Data.Abilities.Count);  i++ )
            {
                if (Input.GetKeyDown(_inputKeyData.AbilityInputKeyList[i]))
                {
                    _playerCore.SkillController.ActivateSkill(_playerCore.Data.Abilities[i]);
                }
            }
        }

    }
}