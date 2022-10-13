using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface ICharacterItemController 
    {
        ICharacterCore Core { get; }
        void Initialize(ICharacterCore core);
    }
}