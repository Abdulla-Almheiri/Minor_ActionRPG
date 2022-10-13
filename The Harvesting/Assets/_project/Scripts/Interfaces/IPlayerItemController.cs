using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayerItemController
    {
        IPlayerCore Core { get;  }
        bool Equip(GameItem gameItem);
        bool Unequip(EquipmentSlotType equipmentSlot);
    }
}