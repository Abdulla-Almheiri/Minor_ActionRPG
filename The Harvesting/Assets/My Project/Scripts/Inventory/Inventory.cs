using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class Inventory
    {
        public int MaxSize = 10;
        public List<Item> Items = new List<Item>();

        public bool AddItem(Item item, int quantity)
        {
            return true;
        }
        public bool RemoveItem(Item item, int quantity)
        {
            return true;
        }
    }
}