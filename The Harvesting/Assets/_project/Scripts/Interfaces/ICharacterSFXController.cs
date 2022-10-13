using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface ICharacterSFXController
    {
        ICharacterCore Core { get;  }
        void Initialize(ICharacterCore core);
    }
}