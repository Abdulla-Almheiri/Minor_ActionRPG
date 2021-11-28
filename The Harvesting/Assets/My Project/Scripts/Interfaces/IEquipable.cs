using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IEquipable : IItem
    {
        bool Equip(IEquipper equiper);

    }
}