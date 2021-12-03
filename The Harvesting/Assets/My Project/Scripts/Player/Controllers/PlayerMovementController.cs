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

    public class PlayerMovementController : CharacterMovementController, IPlayerMovementController
    {
        public new IPlayerCore Core { get; protected set; }

        public void MoveToMousePosition()
        {
            if(Core.CombatController.CanMove() == false)
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

        public void Initialize(IPlayerCore core, NavMeshAgent navMeshAgent)
        {
            Initialize(navMeshAgent);
            Core = core;
        }
    }
}