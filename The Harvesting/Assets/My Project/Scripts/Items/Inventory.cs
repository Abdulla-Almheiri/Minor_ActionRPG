using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class Inventory : MonoBehaviour
    {
        public int MaxSize = 10;
        public List<Item> Items = new List<Item>();

        public abstract void AddItem(Item item);
        public abstract void RemoveItem(Item item, int quantity);
    }
}