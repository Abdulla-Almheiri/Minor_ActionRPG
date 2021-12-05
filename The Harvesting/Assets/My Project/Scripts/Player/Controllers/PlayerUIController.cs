using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    [RequireComponent(typeof(PlayerCombatController))]

    public class PlayerUIController : CharacterUIController, IPlayerUIController
    {
        [SerializeField] private GameObject _playerStatsUIPrefab;
        [SerializeField] private GameObject _characterScreenPrefab;
        [SerializeField] private GameObject _playerSkillUIPrefab;

        public PlayerStatsUIScript  PlayerStatsUIScript { get; protected set; }
        public GameObject CharacterScreen { get => _characterScreenPrefab; }
        public SkillUIScript PlayerSkillUIScript { get; protected set; }

        public new IPlayerCore Core { get; protected set; }

        private void Update()
        {
            UpdateHealthPercentage(Core.CombatController.HealthPercentage());
            UpdateManaPercentage(Core.CombatController.ManaPercentage());

        }

        public void Initialize(IPlayerCore core)
        {
            Core = core;
            base.Initialize(core);
            InitializeUI();
        }
        public void UpdateHealthPercentage(float percentage)
        {
            //_playerStatsUI.UpdateHealthPercentage(percentage);
        }

        public void UpdateManaPercentage(float percentage)
        {
           // _playerStatsUI.UpdateManaPercentage(percentage);
        }

        public void ToggleCharacterScreen()
        {
            //_characterScreen?.SetActive(!_characterScreen.activeSelf);
        }

        public void DisplaySkillsUI()
        {
            //Core.GameManager.SkillUI.DisplaySkillIcons();
        }

        public void UpdateStatsUI()
        {

        }

        private void InitializeUI()
        {
            var statsUI = Instantiate(_playerStatsUIPrefab, Core.GameManager.StaticCanvas.transform);
            var skillUI = Instantiate(_playerSkillUIPrefab, Core.GameManager.StaticCanvas.transform);

            PlayerStatsUIScript = statsUI.GetComponent<PlayerStatsUIScript>();
            PlayerStatsUIScript.Initialize(Core);

            PlayerSkillUIScript = skillUI.GetComponent<SkillUIScript>();
            PlayerSkillUIScript.Initialize(Core);
        }
    }
}