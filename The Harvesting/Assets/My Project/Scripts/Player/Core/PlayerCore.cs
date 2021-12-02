using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using FMODUnity;

namespace Harvesting {

   /* [RequireComponent(typeof(PlayerAnimationController))]
    [RequireComponent(typeof(PlayerCombatController))]
    [RequireComponent(typeof(PlayerSkillController))]
    [RequireComponent(typeof(PlayerItemController))]
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(PlayerUIController))]
    [RequireComponent(typeof(PlayerSFXController))]*/

    public class PlayerCore: CharacterCore, IPlayerCore
    {
        public IPlayerData PlayerData { get; protected set; }
        public PlayerAnimationController AnimationController { get; private set; }
        public ICharacterCombatController CombatController { get; private set; }
        public PlayerSkillController SkillController { get; private set; }
        public PlayerItemController ItemController { get; private set; }
        public PlayerMovementController MovementController { get; private set; }
        public PlayerUIController UIController { get; private set; }
        public PlayerSFXController SFXController { get; private set; }


        public PlayerSkillData PlayerSkillData { get; private set; }
        public PlayerItemData PlayerItemData { get; private set; }

        public PlayerTemplate PlayerTemplate { get; protected set; }

        public void Initialize(IGameManager gameManager)
        {
            
            Initialize(gameManager, GameManager.PlayerTemplate);
            PlayerTemplate = GameManager.PlayerTemplate;
            
            if(PlayerTemplate == null)
            {
                Debug.Log("GameManager.PlayerTemplate is null.");
            }

            AnimationController = GetComponent<PlayerAnimationController>();
            CombatController = GetComponent<PlayerCombatController>();
            SkillController = GetComponent<PlayerSkillController>();
            ItemController = GetComponent<PlayerItemController>();
            MovementController = GetComponent<PlayerMovementController>();
            UIController = GetComponent<PlayerUIController>();
            SFXController = GetComponent<PlayerSFXController>();

            //PlayerSkillData = new PlayerSkillData(CharacterCombatData, GameManager.CoreAttributes, PlayerTemplate);
        }

        public void Awake()
        {
            Initialize(null, null);
        }


        public void Update()
        {
            //TEST
            if (Input.GetKeyDown(KeyCode.F))
            {
                CombatController.LevelUp(5);
            }
        }

        public void ActivateSkill(Skill skill)
        {
            SkillController.ActivateSkill(skill);
        }

        public void ReceiveSkillAction(CharacterCore performer, SkillAction skillAction)
        {
            
        }

        protected void UpdateAbilities()
        {
            PlayerData.Abilities.Clear();

            foreach (ProgressionSkill progressionSkill in PlayerTemplate.Progression)
            {
                if (progressionSkill.Level <= CombatController.AttributeValue(GameManager.CoreAttributesTemplate.Level))
                {
                    PlayerData.Abilities.Add(progressionSkill.Skill);
                }
            }

        }
    }
}
