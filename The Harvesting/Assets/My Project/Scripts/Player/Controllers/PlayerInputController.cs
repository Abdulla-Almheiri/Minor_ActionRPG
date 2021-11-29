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
        private PlayerMovementController _playerMovementController;
        private PlayerUIController _playerUIController;
        private PlayerSkillController _playerSkillController;

        [SerializeField] private InputKeyData _inputKeyData;

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            HandleInput();

            //TEST
            if(Input.GetKeyDown(KeyCode.Q))
            {
                _playerCore.Player.TakeDamage(5f);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _playerCore.Player.GetHealed(5f);
            }
            //TEST
        }
        private void HandleInput()
        {
            WaitForMouseClickToMove();
            HandleUIInput();
            HandleSkillInput();
        }

        public void Initialize()
        {
            _playerCore = GetComponent<PlayerCore>();
            _playerSkillController = GetComponent<PlayerSkillController>();
            _playerMovementController = GetComponent<PlayerMovementController>();
            _playerUIController = GetComponent<PlayerUIController>();
        }

        private void WaitForMouseClickToMove()
        {
            if (Input.GetMouseButton(0))
            {
                _playerMovementController.MoveToMousePosition();
            }
        }

        private void HandleUIInput()
        {
            if (Input.GetKeyDown(_inputKeyData.CharacterScreen))
            {
                _playerUIController.ToggleCharacterScreen();
            }
        }

        private void HandleSkillInput()
        {
            for(int i = 0;  i < Mathf.Min(_inputKeyData.AbilityInputKeyList.Length, _playerCore.Player.Abilities.Count);  i++ )
            {
                if (Input.GetKeyDown(_inputKeyData.AbilityInputKeyList[i]))
                {
                    _playerSkillController.ActivateSkill(_playerCore.Player.Abilities[i]);
                }
            }
        }

    }
}