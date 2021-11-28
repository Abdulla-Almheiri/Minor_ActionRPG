using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayer : ICombatCharacter, IItemPicker, IEquipper, IExperiencePointsReceiver, IInteractor
    {

    }
}