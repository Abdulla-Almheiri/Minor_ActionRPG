using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonsterAnimationController : ICharacterAnimationController
    {
        new IMonsterCore Core { get; }
    }
}
