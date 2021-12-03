using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace Harvesting {

   /* [RequireComponent(typeof(PlayerAnimationController))]
    [RequireComponent(typeof(PlayerCombatController))]
    [RequireComponent(typeof(PlayerSkillController))]
    [RequireComponent(typeof(PlayerItemController))]
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(PlayerUIController))]
    [RequireComponent(typeof(PlayerSFXController))]
    [RequireComponent(typeof(PlayerInputController))]*/
  

    public class PlayerCore: CharacterCore, IPlayerCore
    {
        public new IPlayerData Data { get; protected set; }
        public new IPlayerAnimationController AnimationController { get; protected set; }
        public new IPlayerCombatController CombatController { get; protected set; }
        public new IPlayerSkillController SkillController { get; protected set; }
        public new IPlayerItemController ItemController { get; protected set; }
        public new IPlayerMovementController MovementController { get; protected set; }
        public new IPlayerUIController UIController { get; protected set; }
        public new IPlayerSFXController SFXController { get; protected set; }
        public new IPlayerInputController InputController { get; protected set; }

        public PlayerSkillData PlayerSkillData { get; private set; }
        public PlayerItemData PlayerItemData { get; private set; }

        public new IPlayerTemplate Template { get; protected set; }

        [SerializeField] private List<SkillSpawnLocationData> _skillSpawnLocations;
        public void Initialize(IGameManager gameManager, IPlayerTemplate playerTemplate)
        {
            
            GameManager = gameManager;
            Template = playerTemplate;

            Initialize(gameManager, (CharacterTemplate)Template, GetComponent<Animator>(), GetComponent<NavMeshAgent>(), transform,  _skillSpawnLocations) ;

            Data = new PlayerData();
            Data.Initialize(this, Template);

            if (Template == null)
            {
                Debug.Log("GameManager.PlayerTemplate is null.");
            }

            MovementController = GetComponent<PlayerMovementController>();
            MovementController.Initialize(this, GetComponent<NavMeshAgent>());



            AnimationController = GetComponent<PlayerAnimationController>();
            AnimationController.Initialize(this, GetComponentInChildren<Animator>());

            CombatController = GetComponent<PlayerCombatController>();
            CombatController.Initialize(this);

            SkillController = GetComponent<PlayerSkillController>();

            SkillController.Initialize(this, GameManager.CombatSettings, _skillSpawnLocations);

            InputController = GetComponent<PlayerInputController>();
            InputController.Initialize(this, GameManager.InputKeyData);



        }

        /*public void Awake()
        {
            //TESTING. REMOVE LATER
            var gManager = FindObjectOfType<GameManager>();
            Initialize(gManager, gManager.PlayerTemplate);
        }*/


        public void Update()
        {
            //TEST
            if (Input.GetKeyDown(KeyCode.F))
            {
                CombatController.LevelUp(5);
            }
        }

        public void ReceiveSkillAction(CharacterCore performer, SkillAction skillAction)
        {
            
        }

        protected void UpdateAbilities()
        {
            Data.Abilities.Clear();

            foreach (ProgressionSkill progressionSkill in Template.SkillProgression)
            {
                if (progressionSkill.Level <= CombatController.AttributeValue(GameManager.CoreAttributesTemplate.Level))
                {
                    Data.Abilities.Add(progressionSkill.Skill);
                }
            }

        }
    }
}
