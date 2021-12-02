using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayerCore: ICharacterCore
    {
        IPlayerData PlayerData { get; }
        PlayerTemplate PlayerTemplate { get; }
        void Initialize(IGameManager gameManager);
    }
}