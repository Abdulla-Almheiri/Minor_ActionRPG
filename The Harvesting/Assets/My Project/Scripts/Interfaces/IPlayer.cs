using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayer : ICharacterCombatController, IItemPicker, IEquipper, IExperiencePointsReceiver, IInteractor
    {

    }
}