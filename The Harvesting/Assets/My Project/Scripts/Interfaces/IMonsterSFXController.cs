using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonsterSFXController : ICharacterSFXController
    {
        new IMonsterCore Core { get; }
    }
}