using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IItemPicker
    {
        bool PickUp(IPickable itemToPick);
    }
}