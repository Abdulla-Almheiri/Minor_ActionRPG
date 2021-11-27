using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerInputController : MonoBehaviour
    {
        private PlayerCore _playerCore;
        [SerializeField] private InputKeyData _inputKeyData;

        private KeyCode _characterScreenKeyCode = KeyCode.I;
        private void Awake()
        {
            Initialize();

        }
        
        private void Update()
        {
            HandleInput();
        }
        private void HandleInput()
        {
            if(Input.GetKeyDown(_characterScreenKeyCode))
            {
                _playerCore.PlayerUIController.ToggleCharacterScreen();
            }

            if(Input.GetKeyDown(_inputKeyData.Skill1))
            {
                _playerCore?.PlayerSkillController?.ActivateSkill(1);
            }

            if (Input.GetKeyDown(_inputKeyData.Skill2))
            {
                _playerCore.PlayerSkillController.ActivateSkill(2);
            }

            if (Input.GetKeyDown(_inputKeyData.Skill3))
            {
                _playerCore.PlayerSkillController.ActivateSkill(3);
            }

            if (Input.GetKeyDown(_inputKeyData.Skill4))
            {
                _playerCore.PlayerSkillController.ActivateSkill(4);
            }

            if (Input.GetKeyDown(_inputKeyData.Skill5))
            {
                _playerCore.PlayerSkillController.ActivateSkill(5);
            }

            if (Input.GetKeyDown(_inputKeyData.Skill6))
            {
                _playerCore.PlayerSkillController.ActivateSkill(6);
            }

            if (Input.GetKeyDown(_inputKeyData.Skill7))
            {
                _playerCore.PlayerSkillController.ActivateSkill(7);
            }
        }

        public void Initialize()
        {
            _playerCore = GetComponent<PlayerCore>();
        }
    }
}