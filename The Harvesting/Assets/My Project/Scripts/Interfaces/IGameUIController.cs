using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IGameUIController 
    {
        IGameManager GameManager { get; }
        FloatingCombatTextManager CombatTextManager { get; }
        void Initialize(IGameManager gameManager);
    }
}