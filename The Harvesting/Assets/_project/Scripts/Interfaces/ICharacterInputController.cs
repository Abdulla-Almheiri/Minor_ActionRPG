using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface  ICharacterInputController
    {
        InputKeyData InputKeyData { get; }
        ICharacterCore Core { get; }
        bool MouseClick(out RaycastHit point, LayerMask layerMask);
        void Initialize(ICharacterCore core, InputKeyData inputKeyData);
    }
}