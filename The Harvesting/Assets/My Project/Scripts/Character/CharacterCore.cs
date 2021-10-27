using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(CharacterAnimationController))]
    [RequireComponent(typeof(CharacterCombatController))]
    [RequireComponent(typeof(CharacterSkillController))]
    [RequireComponent(typeof(CharacterMovementController))]

    public class CharacterCore : MonoBehaviour
    {
        private CharacterAnimationController animationController;
        private CharacterCombatController combatController;
        private CharacterSkillController skillController;
        private CharacterMovementController movementController;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Initialize()
        {
            animationController = GetComponent<CharacterAnimationController>();
            combatController = GetComponent<CharacterCombatController>();
            skillController = GetComponent<CharacterSkillController>();
            movementController = GetComponent<CharacterMovementController>();

        }
    }
}