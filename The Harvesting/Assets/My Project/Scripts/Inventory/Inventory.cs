using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [System.Serializable]
    public class Inventory
    {
        public int MaxSize = 10;
        public List<ItemTemplate> Items = new List<ItemTemplate>();
        public int DirtySlot = -1;
        public int AddItem(ItemTemplate item, int quantity)
        {
            if(Items.Count > MaxSize)
            {
                return -1;
            }


            Items.Add(item);
            DirtySlot = Items.Count-1;
            return Items.Count;
        }
        public int RemoveItem(ItemTemplate item, int quantity)
        {
            int index= Items.IndexOf(item);
            if(index >= 0)
            {
                Items[index] = null;
            }
            DirtySlot = Items.Count - 1;
            return Items.Count-1;
        }

        /*public void Fill(Item item)
        {
            for(int i = Items.Count; i< MaxSize; i++)
            {
                Items[i] = item;
            }
        }*/
    }
}