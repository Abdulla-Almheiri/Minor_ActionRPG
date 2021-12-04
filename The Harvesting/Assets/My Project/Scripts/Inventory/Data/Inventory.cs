using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [System.Serializable]
    public class Inventory
    {
        public int MaxSize = 10;
        public List<Item> Items;

        public Inventory(int maxSize = 10, List<Item> items = null)
        {
            MaxSize = maxSize;
            if (items != null)
            {
                Items = new List<Item>(items);
            }
        }


    }
}