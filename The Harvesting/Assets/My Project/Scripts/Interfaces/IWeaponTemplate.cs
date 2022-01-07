using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IWeaponTemplate<T> : IGameItemTemplate<T> where T: IWeaponItem
    {

    }
}