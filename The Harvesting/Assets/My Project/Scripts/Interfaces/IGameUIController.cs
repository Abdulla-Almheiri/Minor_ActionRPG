using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IGameUIController 
    {
        FloatingCombatTextManager CombatTextManager { get; }
    }
}