using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonsterUIController : ICharacterUIController
    {
        new IMonsterCore Core { get; }
    }
}