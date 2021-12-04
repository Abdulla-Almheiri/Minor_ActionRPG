using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayerUIController
    {
        IPlayerCore Core { get; }
        GameObject CharacterScreen { get; }
        void DisplaySkillsUI();
        void ToggleCharacterScreen();
        void UpdateStatsUI();
        void Initialize(IPlayerCore core);
    }
}