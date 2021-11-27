using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [System.Serializable]
    public class ItemDrop
    {

        public ItemTemplate Item;
        [Range(0,100)]
        public float Chance;

        public Item Generate(int level, int requiredLevel)
        {
            if(Random.Range(0f, 100f) <= Chance)
            {
                return null;
            }

            return Item.Generate(level, requiredLevel);
        }
    }
}