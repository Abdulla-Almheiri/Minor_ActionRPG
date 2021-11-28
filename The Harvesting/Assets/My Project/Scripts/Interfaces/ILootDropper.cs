using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface ILootDropper
    {
        public void DropLoot(IPickable lootDrop);
    }
}