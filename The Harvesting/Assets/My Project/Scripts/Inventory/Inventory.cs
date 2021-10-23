using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [System.Serializable]
    public class Inventory
    {
        public int MaxSize = 10;
        public List<Item> Items = new List<Item>();
        public int DirtySlot = -1;
        public int AddItem(Item item, int quantity)
        {
            if(Items.Count >= MaxSize)
            {
                return -1;
            }


            Items.Add(item);
            DirtySlot = Items.Count-1;
            return Items.Count;
        }
        public int RemoveItem(Item item, int quantity)
        {
            Items.Remove(item);
            DirtySlot = Items.Count - 1;
            return Items.Count-1;
        }

        
    }
}