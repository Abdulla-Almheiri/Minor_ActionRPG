using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonsterCore : ICharacterCore
    {
        MonsterData MonsterData { get; }
        void Initialize(IGameManager gameManager, IMonsterTemplate template, MonsterAI monsterAI);

    }
}
