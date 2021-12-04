using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonsterItemController : ICharacterItemController
    {
        new IMonsterCore Core { get; }
        void SpawnLoot();

        void Initialize(IMonsterCore core);
    }
}
