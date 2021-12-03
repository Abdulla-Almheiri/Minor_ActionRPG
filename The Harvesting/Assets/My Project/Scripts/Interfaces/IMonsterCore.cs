using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonsterCore : ICharacterCore
    {
        IMonsterData MonsterData { get; }
    }
}
