using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonsterInputController : ICharacterInputController
    {
        new IMonsterCore Core { get; }
        void Initialize(IMonsterCore core, InputKeyData inputKeyData);

    }
}