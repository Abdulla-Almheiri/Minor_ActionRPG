using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [System.Serializable]
    public class Inventory
    {
        public int MaxSize = 10;
        public List<GameItem> Items;

        public Inventory(int maxSize = 10, List<GameItem> items = null)
        {
            MaxSize = maxSize;
            if (items != null)
            {
                Items = new List<GameItem>(items);
            }
        }


    }
}