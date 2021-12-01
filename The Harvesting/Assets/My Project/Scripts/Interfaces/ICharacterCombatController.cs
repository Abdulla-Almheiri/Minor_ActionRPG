using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface ICharacterCombatController
    {
        CharacterCore CharacterCore { get; }
        CombatSettings CombatSettings { get; }

        void Initialize(CharacterCore characterCore, CombatSettings combatSettings);
    }
}