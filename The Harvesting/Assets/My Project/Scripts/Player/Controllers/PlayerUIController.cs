using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerUIController : MonoBehaviour
    {
        [SerializeField] private PlayerStatsUIScript _playerStatsUI;
        [SerializeField] private GameObject _characterScreen;

        public GameObject CharacterScreen { get => _characterScreen; }

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
    }
}