using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayerInputController : ICharacterInputController
    {
        new IPlayerCore Core { get; }
        void Initialize(IPlayerCore core, InputKeyData inputKeyData);
    }
}