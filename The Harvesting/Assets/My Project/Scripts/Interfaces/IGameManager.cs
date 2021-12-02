using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting {
    public interface IGameManager
    {
        CoreAttributesTemplate CoreAttributesTemplate {get ; }
        PlayerTemplate PlayerTemplate { get; }
        LayerMask Layer { get; }
        IGameUIController UIController { get; }
    }

}
