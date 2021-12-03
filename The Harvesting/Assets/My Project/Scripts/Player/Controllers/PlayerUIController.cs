using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    [RequireComponent(typeof(PlayerCombatController))]

    public class PlayerUIController : CharacterUIController, IPlayerUIController
    {
        [SerializeField] private PlayerStatsUIScript _playerStatsUI;
        [SerializeField] private GameObject _characterScreen;
        [SerializeField] private SkillUIScript _skillUIScript;

        public GameObject CharacterScreen { get => _characterScreen; }

        public new IPlayerCore Core { get; protected set; }

        private void Start()
        {
            Initialize(null);
        }
        private void Update()
        {
            UpdateHealthPercentage(Core.CombatController.HealthPercentage());
            UpdateManaPercentage(Core.CombatController.ManaPercentage());

        }

        private void Initialize(IPlayerCore core)
        {
            Core = core ?? GetComponent<IPlayerCore>();
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
            Core.GameManager.SkillUI.DisplaySkillIcons();
        }

        public void UpdateStatsUI()
        {

        }
    }
}