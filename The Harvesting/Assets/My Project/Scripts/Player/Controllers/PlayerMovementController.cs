using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    [RequireComponent(typeof(PlayerCombatController))]
    [RequireComponent(typeof(PlayerSkillController))]
    [RequireComponent(typeof(PlayerAnimationController))]

    public class PlayerMovementController : CharacterMovementController
    {
        public IPlayerData PlayerData { get; private set; }
        private PlayerCombatController _playerCombatController;
        private PlayerSkillController _playerSkillController;
        private PlayerAnimationController _playerAnimationController;


        private void Start()
        {
            Initialize(Core);
        }

        public void MoveToMousePosition()
        {
            if(_playerCombatController.CanMove() == false)
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit rayHit;

            if (Physics.Raycast(ray, out rayHit, Core.GameManager.Layer))
            {
               MoveToPoint(rayHit.point);
            }

        }

        public void Initialize(ICharacterCore core)
        {
            //PlayerData = new PlayerItemData() as IPlayerData;
            Initialize();
            Core = core;

            _playerCombatController = GetComponent<PlayerCombatController>();
            _playerSkillController = GetComponent<PlayerSkillController>();
            _playerAnimationController = GetComponent<PlayerAnimationController>();
        }
    }
}