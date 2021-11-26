using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class Item
    {
        public ItemType ItemType;
        public string Name;
        public Sprite Icon;
        private ItemTemplate _itemTemplate;
        public abstract void Interact(PlayerCore Player);
        public abstract ItemTemplate Template();
    }
}