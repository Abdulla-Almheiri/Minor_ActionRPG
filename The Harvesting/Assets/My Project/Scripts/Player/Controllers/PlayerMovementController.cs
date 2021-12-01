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
        private PlayerCore _playerCore;

        private PlayerCombatController _playerCombatController;
        private PlayerSkillController _playerSkillController;
        private PlayerAnimationController _playerAnimationController;

        private Animator _animator;


        private void Start()
        {
            Initialize(_playerCore);
        }

        private void Awake()
        {

        }

        private void Update()
        {
           // MoveToMousePosition();
        }

        public void MoveToMousePosition()
        {
            if(_playerCombatController.CanMove() == false)
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit rayHit;

            if (Physics.Raycast(ray, out rayHit, _layer))
            {
               MoveToPoint(rayHit.point);
            }

        }

        public void Initialize(PlayerCore playerCore)
        {
            Initialize();

            _playerCore = playerCore ? playerCore:  GetComponent<PlayerCore>();

            _playerCombatController = GetComponent<PlayerCombatController>();
            _playerSkillController = GetComponent<PlayerSkillController>();
            _playerAnimationController = GetComponent<PlayerAnimationController>();

            _animator = GetComponentInChildren<Animator>();
        }
    }
}