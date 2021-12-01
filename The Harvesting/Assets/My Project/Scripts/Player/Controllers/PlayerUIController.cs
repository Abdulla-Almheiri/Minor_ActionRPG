using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    [RequireComponent(typeof(PlayerCombatController))]

    public class PlayerUIController : MonoBehaviour
    {
        private PlayerCore _playerCore;
        [SerializeField] private PlayerStatsUIScript _playerStatsUI;
        [SerializeField] private GameObject _characterScreen;
        [SerializeField] private SkillUIScript _skillUIScript;

        public GameObject CharacterScreen { get => _characterScreen; }

        private void Start()
        {
            Initialize();
        }
        private void Update()
        {
            UpdateHealthPercentage(_playerCore.Data.HealthPercentage());
            UpdateManaPercentage(_playerCore.Data.ManaPercentage());

        }

        private void Initialize()
        {
            _playerCore = GetComponent<PlayerCore>();
        }
        public void UpdateHealthPercentage(float percentage)
        {
            _playerStatsUI.UpdateHealthPercentage(percentage);
        }

        public void UpdateManaPercentage(float percentage)
        {
            _playerStatsUI.UpdateManaPercentage(percentage);
        }

        public void ToggleCharacterScreen()
        {
            _characterScreen?.SetActive(!_characterScreen.activeSelf);
        }

        public void DisplaySkillsUI()
        {
            _skillUIScript.DisplaySkillIcons();
        }
    }
}