using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [System.Serializable]
    public class ItemDrop
    {
        public Item Item;
        [Range(0,100)]
        public float Chance;

    }
}