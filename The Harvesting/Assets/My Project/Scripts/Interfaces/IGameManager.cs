using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting {
    public interface IGameManager
    {
        Camera Camera { get; } 
        CoreAttributesTemplate CoreAttributesTemplate {get ; }
        CombatSettings CombatSettings { get; }
        InputKeyData InputKeyData { get; }
        IPlayerTemplate PlayerTemplate { get; }
        LayerMask Layer { get; }
        IGameUIController UIController { get; }
        SkillUIScript SkillUI { get; }
        PlayerCore PlayerCore { get; }
        Canvas StaticCanvas { get;  }
        Canvas DynamicCanvas { get; }
        LayerMask PlayerLayer { get; }
    }

}
