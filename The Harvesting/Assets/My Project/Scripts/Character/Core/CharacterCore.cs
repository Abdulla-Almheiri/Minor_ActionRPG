using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    /// <summary>
    /// CharacterCore class. This is used as the Core for the player and monsters.
    /// </summary>
    /// 
    public abstract class CharacterCore : MonoBehaviour, ICharacterCore
    {
        public CharacterData CharacterData { get; protected set; }
        public ICharacterTemplate Template { get; protected set; }
        public IGameManager GameManager { get; protected set; }
        public ICharacterAnimationController AnimationController { get; protected set; }

        public ICharacterCombatController CombatController { get; protected set; }

        public ICharacterSkillController SkillController { get; protected set; }

        public ICharacterMovementController MovementController { get; protected set; }

        public ICharacterAIController AIController { get; protected set; }

        public ICharacterUIController UIController { get; protected set; }

        public ICharacterItemController ItemController { get; protected set; }
        public ICharacterSFXController SFXController { get; protected set; }
        public ICharacterInputController InputController { get; protected set; }
        public GameObject GameObject { get; protected set; }

        public void Initialize(IGameManager gameManager, ICharacterTemplate template, Animator animator, GameObject gameObject, NavMeshAgent navMeshAgent, Transform transform, List<SkillSpawnLocationData> skillSpawnLocations)
        {
            GameManager = gameManager;
            Template = template;
            CharacterData = new CharacterData(this, template);
            GameObject = gameObject;

            MovementController = GetComponent<CharacterMovementController>();
            MovementController.Initialize(this, navMeshAgent, transform);

            InputController = GetComponent<CharacterInputController>();
            InputController.Initialize(this, GameManager.InputKeyData);

   
            AnimationController = GetComponent<CharacterAnimationController>();
            AnimationController.Initialize(this, animator);

            CombatController = GetComponent<CharacterCombatController>();
            CombatController.Initialize(this);




            SkillController = GetComponent<CharacterSkillController>();
            SkillController.Initialize(this, GameManager.CombatSettings, skillSpawnLocations);



        }

    }
}